import './reg.css';
import React, { useState } from 'react';
import axios from 'axios';
import DatePicker from 'react-datepicker';
import 'react-datepicker/dist/react-datepicker.css';
import { useNavigate } from 'react-router-dom';

const Reg = () => {
  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');
  const [firstName, setFirstName] = useState('');
  const [lastName, setLastName] = useState('');
  const [gender, setGender] = useState('');
  const [birthday, setBirthday] = useState(null);
  const [region, setRegion] = useState('');
  const [registrationStatus, setRegistrationStatus] = useState('');
  const navigate = useNavigate();

  const handleSubmit = async (e) => {
    e.preventDefault();
    
    const userData = {
      username,
      password,
      firstName,
      lastName,
      gender,
      birthday,
      region
    };

    try {
      const response = await axios.post('http://morderboy.ru/api/registration', userData);

      if (response.status === 200) {
        setRegistrationStatus('Ok');
        navigate('/login');
      } else {
        setRegistrationStatus('Bad Request');
      }
    } catch (error) {
      console.error(error);
      setRegistrationStatus('Error');
    }
  };

  return (
    <div className='registration-container'>
      <h1>Регистрация</h1>
      {registrationStatus === 'Ok' && <p>Пользователь зарегистрирован 👍</p>}
      {registrationStatus === 'Bad Request' && <p>Пользователь с таким логином уже существует</p>}
      {registrationStatus === 'Error' && <p>Пользователь с таким логином уже существует 😞</p>}<br/>
      <form onSubmit={handleSubmit}>
        <input type="text" value={username} placeholder="Имя пользователя" onChange={(e) => setUsername(e.target.value)} />
       
        <input type="password" value={password} placeholder="Пароль" onChange={(e) => setPassword(e.target.value)} />
  
        <input type="text" value={firstName} placeholder="Имя" onChange={(e) => setFirstName(e.target.value)} />
   
        <input type="text" value={lastName} placeholder="Фамилия" onChange={(e) => setLastName(e.target.value)} />

        <input type="text" value={region} placeholder="Регион" onChange={(e) => setRegion(e.target.value)} />

        <DatePicker selected={birthday} onChange={date => setBirthday(date)} className='dat' placeholderText="Дата рождения" />
 
        <select value={gender} className='gen' onChange={(e) => setGender(e.target.value)}>
          <option value="">Выберите пол</option>
          <option value="male">Мужской</option>
          <option value="female">Женский</option>
        </select>
 
        <button type="submit">Зарегистрироваться</button>
      </form>
    </div>
  );
};

export default Reg;