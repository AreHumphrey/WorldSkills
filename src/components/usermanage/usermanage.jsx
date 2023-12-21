import React, { useEffect, useState } from 'react';
import { useLocation, useNavigate } from 'react-router-dom';
import Log from './../../img/sq.white.png';
import './usermanage.css';

const UserManage = () => {
  const location = useLocation();
  const token = location.state.token;
  const [UsersInfo, setUsersInfo] = useState([]);

  const navigate = useNavigate();


  const handleBackClick = () => {
    navigate('/user', { state: { token } });
  };

  const transformRole = (role) => {
    switch (role) {
      case 'U':
        return 'Пользователь';
      case 'K':
        return 'Координатор';
      case 'A':
        return 'Администратор';
      case 'E':
        return 'Эксперт';
      default:
        return 'no role';
    }
  };

  const transformGender = (role) => {
    switch (role) {
      case 'Male':
        return 'Мужской';
      case 'Female':
        return 'Женский';
      default:
        return 'Не указано';
    }
  };

  useEffect(() => {
    const fetchUsersInfo = async () => {
      try {
        const response = await fetch('http://morderboy.ru/api/usermanagment', {
          headers: {
            Authorization: `Bearer ${token}`
          }
        });
        if (response.ok) {
          const data = await response.json();
          setUsersInfo(data);
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

    fetchUsersInfo();
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

      <div className='info-block2'>
        <h1>Управление Участниками</h1>
        {UsersInfo.map(user => (
          <div key={user.id} className='info1'>
            <p>Email: {user.Email || ""}</p>
            <p>ID: {user.IdNumber || ""}</p>
            <p>Роль: {transformRole(user.RoleName) || ""}</p>
            <p>ФИО: {user.Name || ""}</p>
            <p>Пол: {transformGender(user.Gender) || ""}</p>
            <p>Город: {user.Region || ""}</p>
            <p>Регион: {user.Area || ""}</p>
            <button id='btn_add'>Добавить в чемпионат</button>
          </div>
        ))}
      </div>

    </div>
  );
}

export default UserManage;