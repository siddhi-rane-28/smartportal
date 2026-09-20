import React from 'react';
import VillageDevelopment from '../components/VillageDevelopment/VillageDevelopment';

// Aapke purane cards (example)
import Health from '../components/Health/Health';
import Education from '../components/Education/Education';

const MainDashboard = () => {
    return (
        <div className="dashboard-container">
            <h1>🌾 Smart Gram Panchayat Dashboard</h1>
            <p>Welcome to Digital Village Services</p>

            <div className="dashboard-grid">

                {/* 1. VILLAGE DEVELOPMENT - YEH AAPKA NAYA MAIN CARD */}
                <div className="dashboard-main-card village-dev-highlight">
                    <VillageDevelopment />
                </div>

                {/* 2. Aapke dusre purane cards */}
                <div className="dashboard-main-card">
                    <h2>🏥 Health Services</h2>
                    <button>Open</button>
                </div>

                <div className="dashboard-main-card">
                    <h2>🎓 Education</h2>
                    <button>Open</button>
                </div>

                <div className="dashboard-main-card">
                    <h2>📄 Documents</h2>
                    <button>Open</button>
                </div>

            </div>
        </div>
    );
};

export default MainDashboard;