import './login.css';
import React, { useState } from 'react';
import bl from './../../img/blue.png';
import { useNavigate } from 'react-router-dom';


const Login = () => {
  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');
  const [error, setError] = useState('');

  const navigate = useNavigate();

  const handleSubmit = (e) => {
    e.preventDefault();
    setError('');

    // Создаем объект с данными входа
    const loginData = {
      username: username,
      password: password,
    };

    fetch('http://morderboy.ru/api/login', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
        'withCredentials': true
      },
      body: JSON.stringify(loginData),
    })
      .then((response) => {
        if (response.ok) {
          // Если получили ответ "Ok", обрабатываем ответ
          return response.text();
        } else if (response.status === 404) {
          // Если получили ответ "NotFound", обрабатываем ошибку
          throw new Error('Пользователь не найден');
        } else {
          // Обрабатываем другие ошибки
          throw new Error('Ошибка сервера');
        }
      })
      .then((token) => {
        navigate('/user', { state: { token } });
      })
      .catch((error) => {
        // Обработка ошибки
        setError(error.message);
      });
  };

  return (
    <div className="login-container">
      <img src={bl} alt="Logo" />
      <div className="textlog">
        <h2>Вход в аккаунт</h2>
        <form onSubmit={handleSubmit}>
          <input
            type="text"
            placeholder="Имя пользователя"
            value={username}
            onChange={(e) => setUsername(e.target.value)}
          />
          <input
            type="password"
            placeholder="Пароль"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
          />
          <button type="submit">Войти</button>
          {error && <p className="error-message">{error}</p>}

          <a href='/registration'>Регистрация</a>
        </form>
      </div>
    </div>
  );
};

export default Login;