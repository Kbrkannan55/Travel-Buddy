import React, { useEffect, useState } from 'react';
import Logo from '../../Assets/traveltour1.jpg';
import Logo1 from '../../Assets/TravelTourist.jpg'
import './AvailableAgencies.css';
import { Link } from 'react-router-dom';


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

    const Logout =()=>{
        sessionStorage.removeItem('accessToken')
        sessionStorage.removeItem('refreshToken')
        sessionStorage.removeItem('role')
        sessionStorage.removeItem('packageID')
    }

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
                    <Link style={{ textDecoration: 'none', color: 'black' }} to={'/'}> <li>Home</li></Link>
                    <Link style={{ textDecoration: 'none', color: 'black' }} to={'/'}><li>Image Gallery</li></Link>
                    <Link style={{ textDecoration: 'none', color: 'black' }} to={'/'}><li onClick={Logout}>Logout</li></Link>
                </ul>
            </nav>

            <div className='totaldiv'>
                <div className='leftnav'>
                    <Link style={{ textDecoration: 'none', color: 'black' }} to={'/adminpage'}><div>Approval List</div></Link>
                    <Link style={{ textDecoration: 'none', color: 'black' }} to={'/adminimage'}> <div>Add Images</div></Link>
                    <Link style={{ textDecoration: 'none', color: 'black' }} to={'/avaiableagencies'}><div>Available Agencies</div></Link>
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
