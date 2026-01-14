// SignalR Canlı Veri İstemcisi
const connection = new signalR.HubConnectionBuilder()
    .withUrl("/gameDataHub")
    .withAutomaticReconnect()
    .configureLogging(signalR.LogLevel.Information)
    .build();

// Bağlantı durumu göstergesi
connection.onreconnecting(() => {
    console.log("🔄 Bağlantı yeniden kuruluyor...");
    showConnectionStatus("reconnecting");
});

connection.onreconnected(() => {
    console.log("✅ Bağlantı yeniden kuruldu!");
    showConnectionStatus("connected");
});

connection.onclose(() => {
    console.log("❌ Bağlantı kesildi!");
    showConnectionStatus("disconnected");
});

// 1. KAYNAK GÜNCELLEMELERİ (Köy Yönetimi & Ekonomi)
connection.on("ResourcesUpdated", (data) => {
    updateVillageResources(data);
    updateEconomyTotals();
});

// 2. ASKER GÜNCELLEMELERİ (Garnizon)
connection.on("TroopsUpdated", (data) => {
    updateGarrisonTroops(data);
});

// 3. BİNA İLERLEMESİ (Altyapı)
connection.on("BuildingProgressUpdated", (data) => {
    updateBuildingProgress(data);
});

// 4. SALDIRI DURUMU (Savaş Odası)
connection.on("AttackStatusUpdated", (data) => {
    updateAttackStatus(data);
});

// 5. EKONOMİ TOPLAM (Ekonomi Sayfası)
connection.on("EconomyUpdated", (data) => {
    updateEconomyDashboard(data);
});

// 6. HARİTA GÜNCELLEMESİ (Radar)
connection.on("MapUpdated", (data) => {
    updateMapData(data);
});

// YARDIMCI FONKSİYONLAR

function updateVillageResources(data) {
    const villageCard = document.querySelector(`[data-village-id="${data.villageId}"]`);
    if (!villageCard) return;

    // Kaynak değerlerini güncelle
    const woodEl = villageCard.querySelector('.resource-wood');
    const stoneEl = villageCard.querySelector('.resource-stone');
    const ironEl = villageCard.querySelector('.resource-iron');
    
    if (woodEl) {
        woodEl.textContent = (data.wood / 1000).toFixed(1) + 'k';
        updateProgressBar(villageCard.querySelector('.progress-wood'), data.wood, data.storageCapacity);
    }
    
    if (stoneEl) {
        stoneEl.textContent = (data.stone / 1000).toFixed(1) + 'k';
        updateProgressBar(villageCard.querySelector('.progress-stone'), data.stone, data.storageCapacity);
    }
    
    if (ironEl) {
        ironEl.textContent = (data.iron / 1000).toFixed(1) + 'k';
        updateProgressBar(villageCard.querySelector('.progress-iron'), data.iron, data.storageCapacity);
    }

    // Nüfus güncelle
    const popEl = villageCard.querySelector('.population-current');
    if (popEl) {
        popEl.textContent = data.popCurrent;
        const popPercent = (data.popCurrent / data.popMax) * 100;
        updateProgressBar(villageCard.querySelector('.progress-population'), data.popCurrent, data.popMax);
    }
}

function updateGarrisonTroops(data) {
    const garrisonCard = document.querySelector(`[data-garrison-village="${data.villageId}"]`);
    if (!garrisonCard) return;

    const troopTypes = ['spear', 'sword', 'axe', 'light', 'heavy', 'ram', 'catapult', 'snob'];
    
    troopTypes.forEach(type => {
        const troopEl = garrisonCard.querySelector(`.troop-${type}`);
        if (troopEl && data.troops[type] !== undefined) {
            troopEl.textContent = data.troops[type].toLocaleString();
            
            // Animasyon ekle
            troopEl.classList.add('troop-updated');
            setTimeout(() => troopEl.classList.remove('troop-updated'), 500);
        }
    });
}

function updateBuildingProgress(data) {
    const buildCard = document.querySelector(`[data-build-id="${data.buildId}"]`);
    if (!buildCard) return;

    // İlerleme çubuğunu güncelle
    const progressBar = buildCard.querySelector('.progress-fill');
    if (progressBar) {
        progressBar.style.width = data.progress + '%';
    }

    // Kalan süreyi güncelle
    const countdownEl = buildCard.querySelector('.countdown');
    if (countdownEl && data.remaining) {
        const remainingMs = typeof data.remaining === 'string' ? new Date(data.remaining).getTime() - Date.now() : data.remaining;
        const hours = Math.floor(remainingMs / 3600000);
        const minutes = Math.floor((remainingMs % 3600000) / 60000);
        const seconds = Math.floor((remainingMs % 60000) / 1000);
        countdownEl.textContent = `${String(hours).padStart(2, '0')}:${String(minutes).padStart(2, '0')}:${String(seconds).padStart(2, '0')}`;
    }

    // Tamamlandıysa kartı kaldır
    if (data.progress >= 100) {
        buildCard.classList.add('fade-out');
        setTimeout(() => buildCard.remove(), 500);
    }
}

function updateAttackStatus(data) {
    const attackRow = document.querySelector(`[data-attack-id="${data.attackId}"]`);
    if (!attackRow) return;

    // Durum badge'ini güncelle
    const statusBadge = attackRow.querySelector('.attack-status');
    if (statusBadge) {
        statusBadge.textContent = data.status;
        statusBadge.className = `badge attack-status ${getStatusClass(data.status)}`;
    }

    // Varış zamanını güncelle
    const arrivalEl = attackRow.querySelector('.arrival-time');
    if (arrivalEl && data.arrivalTime) {
        const arrival = new Date(data.arrivalTime);
        arrivalEl.textContent = arrival.toLocaleTimeString('tr-TR', { hour: '2-digit', minute: '2-digit', second: '2-digit' });
    }
}

function updateEconomyDashboard(data) {
    // Toplam kaynakları güncelle
    updateAssetValue('.total-wood', data.totalWood);
    updateAssetValue('.total-stone', data.totalStone);
    updateAssetValue('.total-iron', data.totalIron);

    // Depo alarm sayısını güncelle
    const alertBadge = document.querySelector('.storage-alert-count');
    if (alertBadge) {
        alertBadge.textContent = data.fullStorageCount;
    }
}

function updateMapData(data) {
    // Harita üzerindeki hedefleri güncelle
    // Bu kısım harita implementasyonuna göre özelleştirilmeli
    console.log("Harita güncellendi:", data);
}

function updateProgressBar(progressBar, current, max) {
    if (!progressBar) return;
    const percent = Math.min(100, (current / max) * 100);
    progressBar.style.width = percent + '%';
    
    // Renk değişimi (dolu olunca kırmızı)
    if (percent > 90) {
        progressBar.classList.add('bg-danger');
        progressBar.classList.remove('bg-success', 'bg-warning');
    } else if (percent > 70) {
        progressBar.classList.add('bg-warning');
        progressBar.classList.remove('bg-success', 'bg-danger');
    } else {
        progressBar.classList.add('bg-success');
        progressBar.classList.remove('bg-warning', 'bg-danger');
    }
}

function updateAssetValue(selector, value) {
    const el = document.querySelector(selector);
    if (el) {
        el.textContent = value.toLocaleString();
        el.classList.add('value-updated');
        setTimeout(() => el.classList.remove('value-updated'), 300);
    }
}

function getStatusClass(status) {
    const statusMap = {
        'Scheduled': 'bg-warning',
        'Sent': 'bg-info',
        'Arrived': 'bg-success',
        'Failed': 'bg-danger'
    };
    return statusMap[status] || 'bg-secondary';
}

function showConnectionStatus(status) {
    const indicator = document.querySelector('.connection-indicator');
    if (!indicator) return;

    const statusMap = {
        'connected': { icon: '🟢', text: 'Bağlı', class: 'text-success' },
        'reconnecting': { icon: '🟡', text: 'Yeniden Bağlanıyor', class: 'text-warning' },
        'disconnected': { icon: '🔴', text: 'Bağlantı Kesildi', class: 'text-danger' }
    };

    const config = statusMap[status];
    indicator.innerHTML = `<span class="${config.class}">${config.icon} ${config.text}</span>`;
}

// Bağlantıyı başlat
connection.start()
    .then(() => {
        console.log("✅ SignalR bağlantısı kuruldu!");
        showConnectionStatus("connected");
    })
    .catch(err => {
        console.error("❌ SignalR bağlantı hatası:", err);
        showConnectionStatus("disconnected");
    });
