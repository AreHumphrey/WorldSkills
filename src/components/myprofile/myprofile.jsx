import React, { useEffect, useState } from 'react';
import { useLocation, useNavigate } from 'react-router-dom';
import Log from './../../img/sq.white.png';
import './myprofile.css';

const Myprofile = () => {
  const location = useLocation();
  const token = location.state.token;
  const [profileInfo, setProfileInfo] = useState({});

  const navigate = useNavigate();


  const handleBackClick = () => {
    navigate('/user', { state: { token } });
  };

  useEffect(() => {
    const fetchProfileInfo = async () => {
      try {
        const response = await fetch('http://morderboy.ru/api/getprofile', {
          headers: {
            Authorization: `Bearer ${token}` 
          }
        });
        if (response.ok) {
          const data = await response.json();
          setProfileInfo(data);
        } else if (response.status === 401) {
          throw new Error('У пользователя нет claims');
        } else if (response.status === 404) {
          throw new Error('Пользователь не найден');
        } else {
          throw new Error('Произошла ошибка');
        }
      } catch (error) {
        console.error(error);
      }
    };

    fetchProfileInfo();
  }, [token]);

  return (
    <div className='container_profile1'>
        <div className="user_row1">
            <div className="user_logo1">
                <img src={Log} alt='Logo' />
            </div>
            <h1>WorldSkills Russia</h1>
            <button onClick={handleBackClick}>Назад</button>
        </div>

        <div className='info-block'>
            <h1>Мой Профиль</h1>
            <div className='info1'>
                <p>ID: {profileInfo.IdNumber || ""}</p>
                <p>Name: {profileInfo.Name || ""}</p>
                <p>Gender: {profileInfo.Gender || ""}</p>
                <p>Region: {profileInfo.Region || ""}</p>
                <p>Area: {profileInfo.Area || ""}</p>
            </div>
        </div>
    </div>
  );
}

export default Myprofile;