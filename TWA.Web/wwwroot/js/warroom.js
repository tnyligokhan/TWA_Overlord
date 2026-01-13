// HAYALET TREN BUTONU
$('#btn-ghost-train').click(function() {
    var target = $('#target-coords').val();
    // Koordinatları ayır (XXX|YYY formatı varsayılıyor)
    if (!target.includes('|')) {
        toastr.error('Hatalı format! Örn: 500|500');
        return;
    }
    
    var coords = target.split('|');
    var targetX = coords[0];
    var targetY = coords[1];
    var sourceId = $('#source-village-id').val(); // Gizli inputtan al

    // SignalR veya AJAX ile backend'i tetikle
    $.post('/Warfare/LaunchGhostTrain', { sourceId: sourceId, targetX: targetX, targetY: targetY }, function(res) {
        if(res.success) {
            toastr.success('👻 Hayalet Tren Raylarda!');
        } else {
            toastr.error('Hata: ' + res.message);
        }
    });
});

// SNIPE HESAPLAYICI
$('#calculate-snipe').click(function() {
    var arrivalVal = $('#arrival-time').val();
    if (!arrivalVal) {
        toastr.warning("Lütfen varış saati seçin!");
        return;
    }

    var targetTime = new Date(arrivalVal);
    var unitSpeed = 30; // Şahmerdan hızı (dk) - İleride birim seçimi eklenebilir
    
    // Anlık koordinatları al (Örnek veriler, gerçekte inputtan alınmalı)
    var targetStr = $('#target-coords').val();
    if (!targetStr || !targetStr.includes('|')) return;
    
    var sourceStr = $('#source-coords').val(); // Mevcut köy
    
    var tCoords = targetStr.split('|');
    var sCoords = sourceStr.split('|');
    
    // Mesafe
    var dist = Math.sqrt(Math.pow(tCoords[0]-sCoords[0], 2) + Math.pow(tCoords[1]-sCoords[1], 2));
    
    var travelMs = dist * unitSpeed * 60 * 1000;
    var launchDate = new Date(targetTime.getTime() - travelMs);
    
    $('#launch-time-display').text(launchDate.toLocaleTimeString());
    toastr.info("Çıkış saati hesaplandı: " + launchDate.toLocaleTimeString());
});
