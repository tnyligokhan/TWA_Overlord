/**
 * AJAX-based Synchronization Service
 * Handles village data sync without page reload
 */

class SyncService {
    constructor() {
        this.isLoading = false;
        this.abortController = null;
    }

    /**
     * Sync single village
     */
    async syncVillage(villageId) {
        if (this.isLoading) {
            console.warn('Sync already in progress');
            return;
        }

        this.isLoading = true;
        this.abortController = new AbortController();

        try {
            this.showLoadingState(villageId);

            const response = await fetch(`/api/sync/village/${villageId}`, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                signal: this.abortController.signal,
                timeout: 30000 // 30 second timeout
            });

            const result = await response.json();

            if (result.success) {
                this.updateVillageUI(result.data);
                this.showSuccessNotification(result.message);
            } else {
                this.showErrorNotification(result.message);
            }

            return result;
        } catch (error) {
            if (error.name === 'AbortError') {
                this.showErrorNotification('Senkronizasyon iptal edildi');
            } else {
                this.showErrorNotification('Bağlantı hatası: ' + error.message);
            }
            throw error;
        } finally {
            this.isLoading = false;
            this.hideLoadingState(villageId);
        }
    }

    /**
     * Sync all villages
     */
    async syncAllVillages() {
        if (this.isLoading) {
            console.warn('Sync already in progress');
            return;
        }

        this.isLoading = true;
        this.abortController = new AbortController();

        try {
            this.showGlobalLoadingState();

            const response = await fetch('/api/sync/all', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                signal: this.abortController.signal
            });

            const result = await response.json();

            if (result.success) {
                this.showSuccessNotification(result.message);
                
                // Reload page after successful sync to show all updates
                setTimeout(() => {
                    window.location.reload();
                }, 1500);
            } else {
                this.showErrorNotification(result.message);
            }

            return result;
        } catch (error) {
            if (error.name === 'AbortError') {
                this.showErrorNotification('Senkronizasyon iptal edildi');
            } else {
                this.showErrorNotification('Bağlantı hatası: ' + error.message);
            }
            throw error;
        } finally {
            this.isLoading = false;
            this.hideGlobalLoadingState();
        }
    }

    /**
     * Cancel ongoing sync
     */
    cancelSync() {
        if (this.abortController) {
            this.abortController.abort();
        }
    }

    /**
     * Update village UI with new data
     */
    updateVillageUI(data) {
        // Update resources
        this.updateElement(`#wood-${data.id}`, data.wood);
        this.updateElement(`#stone-${data.id}`, data.stone);
        this.updateElement(`#iron-${data.id}`, data.iron);
        
        // Update population
        this.updateElement(`#population-${data.id}`, `${data.populationCurrent}/${data.populationMax}`);
        
        // Update troops if elements exist
        if (data.ownedTroops) {
            Object.keys(data.ownedTroops).forEach(troopType => {
                this.updateElement(`#troop-${troopType}-${data.id}`, data.ownedTroops[troopType]);
            });
        }

        // Trigger custom event for other components to listen
        window.dispatchEvent(new CustomEvent('villageUpdated', { detail: data }));
    }

    /**
     * Update DOM element with animation
     */
    updateElement(selector, value) {
        const element = document.querySelector(selector);
        if (element) {
            const oldValue = element.textContent;
            if (oldValue !== value.toString()) {
                element.classList.add('updating');
                element.textContent = value;
                
                setTimeout(() => {
                    element.classList.remove('updating');
                    element.classList.add('updated');
                    setTimeout(() => element.classList.remove('updated'), 1000);
                }, 100);
            }
        }
    }

    /**
     * Show loading state for specific village
     */
    showLoadingState(villageId) {
        const btn = document.querySelector(`[data-sync-village="${villageId}"]`);
        if (btn) {
            btn.disabled = true;
            btn.innerHTML = '<i class="fas fa-spinner fa-spin me-1"></i> Senkronize ediliyor...';
        }
    }

    /**
     * Hide loading state for specific village
     */
    hideLoadingState(villageId) {
        const btn = document.querySelector(`[data-sync-village="${villageId}"]`);
        if (btn) {
            btn.disabled = false;
            btn.innerHTML = '<i class="fas fa-sync me-1"></i> Senkronize Et';
        }
    }

    /**
     * Show global loading state
     */
    showGlobalLoadingState() {
        const btn = document.querySelector('[data-sync-all]');
        if (btn) {
            btn.disabled = true;
            btn.innerHTML = '<i class="fas fa-spinner fa-spin me-1"></i> Tüm Köyler Senkronize Ediliyor...';
        }

        // Show progress overlay
        const overlay = document.createElement('div');
        overlay.id = 'sync-overlay';
        overlay.className = 'sync-overlay';
        overlay.innerHTML = `
            <div class="sync-progress">
                <div class="spinner-border text-primary mb-3" role="status">
                    <span class="visually-hidden">Yükleniyor...</span>
                </div>
                <h5 class="text-white">Veri Senkronizasyonu</h5>
                <p class="text-muted">Köyler güncelleniyor, lütfen bekleyin...</p>
            </div>
        `;
        document.body.appendChild(overlay);
    }

    /**
     * Hide global loading state
     */
    hideGlobalLoadingState() {
        const btn = document.querySelector('[data-sync-all]');
        if (btn) {
            btn.disabled = false;
            btn.innerHTML = '<i class="fas fa-sync me-1"></i> Veri Senkronizasyonu';
        }

        const overlay = document.getElementById('sync-overlay');
        if (overlay) {
            overlay.remove();
        }
    }

    /**
     * Show success notification
     */
    showSuccessNotification(message) {
        this.showToast(message, 'success');
    }

    /**
     * Show error notification
     */
    showErrorNotification(message) {
        this.showToast(message, 'error');
    }

    /**
     * Show toast notification
     */
    showToast(message, type = 'info') {
        // Remove existing toasts
        document.querySelectorAll('.sync-toast').forEach(t => t.remove());

        const toast = document.createElement('div');
        toast.className = `sync-toast sync-toast-${type}`;
        toast.innerHTML = `
            <div class="d-flex align-items-center gap-2">
                <i class="fas fa-${type === 'success' ? 'check-circle' : 'exclamation-circle'}"></i>
                <span>${message}</span>
            </div>
        `;
        document.body.appendChild(toast);

        // Animate in
        setTimeout(() => toast.classList.add('show'), 10);

        // Auto remove after 3 seconds
        setTimeout(() => {
            toast.classList.remove('show');
            setTimeout(() => toast.remove(), 300);
        }, 3000);
    }
}

// Global instance
window.syncService = new SyncService();

// Auto-initialize on DOM ready
document.addEventListener('DOMContentLoaded', function() {
    // Bind sync buttons
    document.querySelectorAll('[data-sync-village]').forEach(btn => {
        btn.addEventListener('click', function(e) {
            e.preventDefault();
            const villageId = this.getAttribute('data-sync-village');
            window.syncService.syncVillage(villageId);
        });
    });

    document.querySelectorAll('[data-sync-all]').forEach(btn => {
        btn.addEventListener('click', function(e) {
            e.preventDefault();
            window.syncService.syncAllVillages();
        });
    });
});
