import Log from './../../img/sq.white.png'
import './user.css';
import { useLocation, useNavigate } from 'react-router-dom';
import React, { useState, useEffect } from 'react';
import 'react-datepicker/dist/react-datepicker.css';

const User = () => {
  const [username, setUsername] = useState('');
  const [userRole, setUserRole] = useState('');
  
  const location = useLocation();
  const [token, setToken] = useState(location.state.token || '');

  const navigate = useNavigate();

  const currentTime = new Date();
  const currentHour = currentTime.getHours();
  let greeting;

  if (currentHour < 12) {
    greeting = 'Доброе утро';
  } else if (currentHour < 18) {
    greeting = 'Добрый день';
  } else {
    greeting = 'Добрый вечер';
  }

  const handleLogout = () => {
    setToken('');
    navigate('/');
  };

  const handleMyProfileClick = () => {
    navigate('/profile', { state: { token } });
  };

  const handleMyResultClick = () => {
    navigate('/result', { state: { token } });
  };


  useEffect(() => {
    const fetchUsername = async () => {
      try {
        const response = await fetch('http://morderboy.ru/api/getname', {
          headers: {
            Authorization: `Bearer ${token}` 
          }
        });

        if (response.ok) {
          const data = await response.json();
          setUsername(data.name);
        } else if (response.status === 404) {
          // Обработка ошибки NotFound
          throw new Error('У пользователя нет claims');
        } else {
          // Обработка других ошибок
          throw new Error('Ошибка сервера');
        }
      } catch (error) {
        console.error(error);
      }
    };

    fetchUsername();

    const fetchUserRole = async () => {
      try {
        const response = await fetch('http://morderboy.ru/api/getprofile/getrole', {
          headers: {
            Authorization: `Bearer ${token}`
          }
        });
    
        if (response.ok) {
          const data = await response.text();
          setUserRole(data);  // Устанавливаем полученную роль в состояние userRole
        } else if (response.status === 404) {
          throw new Error('У пользователя нет claims');
        } else {
          throw new Error('Ошибка сервера');
        }
      } catch (error) {
        console.error(error);
      }
    };
    
    fetchUserRole();

  }, [token]);

  return (
    <div className='container_profile'>

            <div className="user_row">
                <div className="user_logo">
                    <img src={Log} alt='Logo'/>
                </div>
                <h1>WorldSkills Russia</h1>
                <button onClick={handleLogout}>Выйти</button>
            </div>

      {/* <button id='btn_back'>Назад</button>
      <button id='btn_quit'>Выйти</button> */}

      {userRole === 'U' && (
        <div className='participate' id='member'>
          <h2>Меню Участника</h2>
          <p>{greeting},
            Ms/Mrs {username}!</p>
          <div className='control_btns'>
          <button onClick={handleMyProfileClick}>Мой профиль</button><br></br>
            <button id='btn_competention'>Моя компетенция</button><br></br>
            <button onClick={handleMyResultClick}>Мои результаты</button>
          </div>
        </div>
      )}

      {userRole === 'K' && (
        <div className='participate' id='coordinatior'>
          <h2>Меню Координатора</h2>
          <p>{greeting},
            Ms/Mrs {username}!</p>
          <div className='control_btns'>
            <button id='btn_volunteers_manage'>Управление волонтерами</button><br></br>
            <button id='btn_sponsors_manage'>Управление спонсорами</button><br></br>
            <button id='btn_my_results'>Мои результаты</button>
          </div>
        </div>
      )}

      {userRole === 'A' && (
        <div className='participate' id='admin'>
          <h2>Меню Администратора</h2>
          <p>{greeting},
            Ms/Mrs {username}!</p>
          <div className='control_btns'>
            <button id='btn_champ_manage'>Управление чемпионатами</button><br></br>
            <button id='btn_members_manage'>Управление участниками</button>
          </div>
        </div>
      )}

      {userRole === 'E' && (
        <div className='participate' id='expert'>
          <h2>Меню Эксперта</h2>
          <p>{greeting},
            Ms/Mrs {username}!</p>
          <div className='control_btns'>
            <button id='btn_draw'>Жеребьевка</button><br></br>
            <button id='btn_marks_input'>Ввод оценок</button><br></br>
            <button id='btn_view_results'>Просмотр результатов</button>
          </div>
        </div>
      )}

      <p>N дней N часов и N минут до начала чемпионата!</p>
    </div>
  );
};

export default User;
