import React, { useState } from 'react';
import { TextField, Button } from '@mui/material';
import { toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import './Register.css';
import Navbar from '../Navbar/Navbar';
import { Link, useNavigate } from 'react-router-dom';
import Footer from '../Footer/Footer';

const Register = () => {
  const [userDTO, setUserDTO] = useState({
    name: '',
    username: '',
    email: '',
    phone: '',
    role: 'User',
    password: '',
  });
  const [success, setSuccess] = useState(false);
  const [errors, setErrors] = useState({});
  const navigate = useNavigate()

  const validateForm = () => {
    const newErrors = {};

    if (!userDTO.name) {
      newErrors.name = 'Name is required';
    }
    if (!userDTO.phone) {
      newErrors.phone = 'Phone Number is required';
    } else if (!/^\d{10}$/.test(userDTO.phone)) {
      newErrors.phone = 'Only 10 digits numbers are allowed';
    }
    if (!userDTO.username) {
      newErrors.username = 'Username is required';
    }
    if (!userDTO.email) {
      newErrors.email = 'Email is required';
    } else if (!/\S+@\S+\.\S+/.test(userDTO.email)) {
      newErrors.email = 'Invalid email address';
    }
    if (!userDTO.password) {
      newErrors.password = 'Password is required';
    } else if (userDTO.password.length < 6) {
      newErrors.password = 'Password must be at least 6 characters';
    }

    setErrors(newErrors);
    return Object.keys(newErrors).length === 0;
  };

  const register = () => {
    if (validateForm()) {
      console.log(userDTO);
      fetch('https://localhost:7050/api/Auth/register', {
        method: 'POST',
        headers: {
          accept: 'text/plain',
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(userDTO),
      }).then(async (data) => {
        if (data.status === 200) {
          // for toast message successfully
          var user = await data.json();
          setSuccess(true);
          toast.success('Registered successfully!');
          navigate('/book')
        } else {
          toast.error('Warning !');
        }
      });
    }
  };

  return (
    <>
    <Navbar/>
    <div className="user-register-container">
    
      <div className="user-register-title">User Register</div>
      <div className="input-container">
        <TextField
          fullWidth
          label="Full Name"
          variant="outlined"
          value={userDTO.name}
          onChange={(event) => setUserDTO({ ...userDTO, name: event.target.value })}
          error={!!errors.name}
          helperText={errors.name}
    
        />
      </div>
      <div className="input-container">
        <TextField
          fullWidth
          label="Username"
          variant="outlined"
          value={userDTO.username}
          onChange={(event) => setUserDTO({ ...userDTO, username: event.target.value })}
          error={!!errors.username}
          helperText={errors.username}
        />
      </div>
      <div className="input-container">
        <TextField
          fullWidth
          label="Email"
          variant="outlined"
          value={userDTO.email}
          onChange={(event) => setUserDTO({ ...userDTO, email: event.target.value })}
          error={!!errors.email}
          helperText={errors.email}
        />
      </div>
      <div className="input-container">
        <TextField
          fullWidth
          label="Phone Number"
          variant="outlined"
          value={userDTO.phone}
          onChange={(event) => {
            const numericValue = event.target.value.replace(/\D/g, '');
            setUserDTO({ ...userDTO, phone: numericValue });
          }}
          error={!!errors.phone}
          helperText={errors.phone}
        />
      </div>
      <div className="input-container">
        <TextField
          fullWidth
          type="password"
          label="Password"
          variant="outlined"
          value={userDTO.password}
          onChange={(event) => setUserDTO({ ...userDTO, password: event.target.value })}
          error={!!errors.password}
          helperText={errors.password}
        />
      </div>
      <div className="button-container">
        <Button variant="contained" color="primary" onClick={register}>
          Register
        </Button>&nbsp;&nbsp;&nbsp;
        <Button variant="contained" color="secondary">
         <Link style={{textDecoration:'none',color:'white',width:'60px'}} to={'/login'}>Login</Link>
        </Button>
      </div>
      {success && <div className="success">Registered successfully!</div>}
    </div>
    <div className="register-footerdiv" style={{marginTop:'25px'}}></div>
    <Footer/>
    </>
  );
};

export default Register;
