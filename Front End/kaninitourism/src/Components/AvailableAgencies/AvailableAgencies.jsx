import React, { useEffect, useState } from 'react';
import Logo from '../../Assets/traveltour1.jpg';
import Logo1 from '../../Assets/TravelTourist.jpg'
import './AvailableAgencies.css';


const AvailableAgencies = () => {
    const [showLink, setShowLink] = useState(false);
    const [agent, setAgent] = useState([]);

    const toggleLinks = () => {
        setShowLink(!showLink);
    };

    useEffect(() => {
        getAllAgentDetails();
    }, []);

   
    const DeleteAgent = (agentId) => {
        const deleteUrl = `https://localhost:7050/api/Auth/Delete?id=${agentId}`;

        fetch(deleteUrl, {
            method: 'DELETE',
            headers: {
                'Content-Type': 'application/json',
                // Add any other headers you may need, such as authorization headers
            },
        })
            .then(response => {
                if (response.ok) {
                    console.log('Agent deleted successfully');
                    window.location.reload();
                } else {
                    throw new Error('Failed to delete agent');
                }
            })
            .catch(error => {
                console.error('Error deleting agent:', error);
            });
    };

    const getAllAgentDetails = () => {
        fetch('https://localhost:7050/api/Auth', {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json',
                // Add any other headers you may need, such as authorization headers
            },
        })
            .then(response => {
                if (response.ok) {
                    return response.json();
                } else {
                    throw new Error('Failed to fetch agent details');
                }
            })
            .then(data => {
                console.log('Agent details:', data);
                setAgent(data);
            })
            .catch(error => {
                console.error('Error fetching agent details:', error);
            });
    };

    return (
        <div>
            <nav className="navbar">
                <div className="navbar-logo">
                    <img className='image-logo' src={Logo} alt="Logo" />
                </div>
                <div className={`navbar-toggle ${showLink ? 'active' : ''}`} onClick={toggleLinks}>
                    <span></span>
                    <span></span>
                    <span></span>
                </div>
                <ul className={`navbar-links ${showLink ? 'active' : ''}`}>
                    <li>Home</li>
                    <li>Image Gallery</li>
                    <li>Logout</li>
                </ul>
            </nav>

            <div className='totaldiv'>
                <div className='leftnav'>
                    <div>Approval List</div>
                    <div>Add Images</div>
                    <div>Available Agencies</div>
                </div>
                <h3 className="card-title" style={{ marginLeft: '320px' }}>Availabe Agencies</h3>
                <div className="approvallist">
                    <table className="table table-bordered">
                        <thead>
                            <tr>
                                <th>Username</th>
                                <th>Name</th>
                                <th>Phone Number</th>
                                <th>Email</th>
                                {/* <th>Password</th> */}
                                <th>Action</th>
                                
                            </tr>
                        </thead>
                        <tbody>
                            {agent.map((agents, index) => (
                                <tr key={index}>
                                    
                                    <td>{agents.username}</td>
                                    <td>{agents.name}</td>
                                    <td>{agents.phone}</td>
                                    <td>{agents.email}</td>
                                    {/* <td>{agents.password}</td> */}
                                   
                                    <td><button onClick={() => DeleteAgent(agents.id)}>Decline</button></td>
                                </tr>
                            ))}
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    );
};

export default AvailableAgencies;
