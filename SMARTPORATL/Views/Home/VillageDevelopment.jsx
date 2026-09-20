import React, { useState } from 'react';
import './VillageDevelopment.css';
import WaterSupply from './cards/WaterSupply';
import Electricity from './cards/Electricity';
import Roads from './cards/Roads';
import Garbage from './cards/Garbage';
import StreetLight from './cards/StreetLight';
import GrampanchayatWork from './cards/GrampanchayatWork';

const VillageDevelopment = () => {
    const [activeCard, setActiveCard] = useState(null);

    const services = [
        { id: 'water', title: 'Water Supply', icon: '💧', component: <WaterSupply /> },
        { id: 'electricity', title: 'Electricity', icon: '⚡', component: <Electricity /> },
        { id: 'roads', title: 'Roads & Infra', icon: '🛣️', component: <Roads /> },
        { id: 'garbage', title: 'Garbage & Swachhata', icon: '🗑️', component: <Garbage /> },
        { id: 'streetlight', title: 'Street Light', icon: '💡', component: <StreetLight /> },
        { id: 'gpwork', title: 'Grampanchayat Work', icon: '🏫', component: <GrampanchayatWork /> },
    ];

    return (
        <div className="village-dev-container">
            {/* Main Dashboard Card */}
            <div className="main-card">
                <h2>Village Development</h2>
                <p>All village development services at one place</p>
                <div className="service-grid">
                    {services.map((service) => (
                        <div key={service.id} className="service-card" onClick={() => setActiveCard(service.id)}>
                            <span className="icon">{service.icon}</span>
                            <h4>{service.title}</h4>
                            <button>View Details</button>
                        </div>
                    ))}
                </div>
            </div>

            {/* Inner Card Details Modal */}
            {activeCard && (
                <div className="modal-overlay" onClick={() => setActiveCard(null)}>
                    <div className="modal-content" onClick={(e) => e.stopPropagation()}>
                        <button className="close-btn" onClick={() => setActiveCard(null)}>X</button>
                        {services.find(s => s.id === activeCard)?.component}
                    </div>
                </div>
            )}
        </div>
    );
};

export default VillageDevelopment;