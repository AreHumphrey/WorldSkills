import React, { useEffect, useState } from 'react';
import { useLocation, useNavigate } from 'react-router-dom';
import Log from './../../img/sq.white.png';
import './myresult.css';

const Myresult = () => {
  const location = useLocation();
  const token = location.state.token;

  const navigate = useNavigate();

  const [results, setResults] = useState([]);


  const handleBackClick = () => {
    navigate('/user', { state: { token } });
  };


  useEffect(() => {
    const fetchResults = async () => {
      try {
        const response = await fetch('http://morderboy.ru/api/getresults', {
          headers: {
            Authorization: `Bearer ${token}`
          }
        });
        if (response.ok) {
          const data = await response.json();
          const resultsArray = Object.values(data);
          setResults(resultsArray);
        } else if (response.status === 401) {
          throw new Error('У пользователя нет claims');
        } else if (response.status === 404) {
          throw new Error('Пользователь не найден');
        } else if (response.status === 204) {
          throw new Error('У пользователя нет результатов');
        } else {
          throw new Error('Произошла ошибка');
        }
      } catch (error) {
        console.error(error);
      }
    };

    fetchResults();
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
        <div className='N'><h1>Мои Результаты</h1></div>
        <div className="results-container">
        {results.length > 0 ? (
          results.map((result, index) => (
            <div key={index} className="result-item">
              <p>ChampName: {result.ChampName}</p>
              <p>Competence: {result.Competence}</p>
              <p>Module: {result.Module}</p>
              <p>Grade: {result.Grade}</p>
            </div>
          ))
        ) : (
          <p>У пользователя пока нет результатов</p>
        )}
      </div>

        
    </div>
  );
}

export default Myresult;