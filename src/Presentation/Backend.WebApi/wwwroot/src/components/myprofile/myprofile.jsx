import React, { useEffect, useState } from 'react';
import { useLocation, useNavigate } from 'react-router-dom';
import Log from './../../img/sq.white.png';
import './myprofile.css';

const Myprofile = () => {
  const location = useLocation();
  const token = location.state.token;
  const [profileInfo, setProfileInfo] = useState({});

  const navigate = useNavigate();

  const [newEmail, setNewEmail] = useState('');
  const [emailChanged, setEmailChanged] = useState(false);
  const [currentEmail, setCurrentEmail] = useState('');

  const [newPassword, setNewPassword] = useState('');
  const [passwordChanged, setPasswordChanged] = useState(false);

  const handleChangePassword = async () => {
    try {
      const response = await fetch('http://morderboy.ru/api/changepassword', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
          Authorization: `Bearer ${token}`
        },
        body: JSON.stringify({ email: currentEmail, password: newPassword })
      });

      if (response.ok) {
        setPasswordChanged(true);
        setNewPassword('');
        setCurrentEmail('');
      } else if (response.status === 400) {
        throw new Error('Пользователь найден, но обновление данных в БД не удалось');
      } else if (response.status === 404) {
        throw new Error('Пользователь с такой почтой не зарегистрирован');
      } else {
        throw new Error('Произошла ошибка');
      }
    } catch (error) {
      console.error(error);
    }
  };

  const handleChangeEmail = async () => {
    try {
      const response = await fetch('http://morderboy.ru/api/changeemail', {
        method: 'PATCH',
        headers: {
          'Content-Type': 'application/json',
          Authorization: `Bearer ${token}` 
        },
        body: JSON.stringify({ email: newEmail })
      });

      if (response.ok) {
        setEmailChanged(true);
        setNewEmail('');
      } else if (response.status === 404) {
        throw new Error('Пользователь не найден в системе');
      } else if (response.status === 500) {
        throw new Error('Internal Server Error');
      } else {
        throw new Error('Произошла ошибка');
      }
    } catch (error) {
      console.error(error);
    }
  };


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
                <div className='in'>
                  <p>ID: {profileInfo.IdNumber || ""}</p>
                  <p>ФИО: {profileInfo.Name || ""}</p>
                  <p>Пол: {profileInfo.Gender || ""}</p>
                  <p>Город: {profileInfo.Region || ""}</p>
                  <p>Регион: {profileInfo.Area || ""}</p>
                </div>
                <div className='change'>
                  <h2>Смена Email</h2>
                  <input
                    type="email"
                    value={newEmail}
                    onChange={(e) => setNewEmail(e.target.value)}
                    placeholder="Enter new email"
                  />
                  <button onClick={handleChangeEmail}>Изменить Email</button>
                  <h2>Смена Пароля</h2>
                  <input
                    type="email"
                    value={currentEmail}
                    onChange={(e) => setCurrentEmail(e.target.value)}
                    placeholder="Enter current email"
                  />
                  <input
                    type="password"
                    value={newPassword}
                    onChange={(e) => setNewPassword(e.target.value)}
                    placeholder="Enter new password"
                  />
                  <button onClick={handleChangePassword}>Изменить Пароль</button>
                </div>
              </div>
              
        </div>
        {passwordChanged && <p className="success-message">Пароль успешно изменён!</p>}
        {emailChanged && <p className="success-message">Email успешно изменён!</p>}
        
    </div>
  );
}

export default Myprofile;