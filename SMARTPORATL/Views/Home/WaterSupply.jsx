import React from 'react';

const WaterSupply = () => {
    return (
        <div>
            <h3>💧 Water Supply Services</h3>
            <div className="inner-options">
                <div className="option"><h4>📖 About</h4><p>Jal Jeevan Mission - Har Ghar Jal</p></div>
                <div className="option"><h4>💻 Online Bill</h4><a href="https://ejal.gov.in" target="_blank" rel="noreferrer"><button>Pay Online</button></a></div>
                <div className="option"><h4>🏢 Offline Info</h4><p>Visit: Grampanchayat Office<br />Time: 10 AM - 5 PM<br />Contact: 98xxxxxx10</p></div>
                <div className="option"><h4>📝 Complaint</h4><button>Raise Complaint - No Water / Dirty Water</button></div>
            </div>
        </div>
    );
};
export default WaterSupply;