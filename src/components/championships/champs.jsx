import React, { useEffect, useState } from 'react';
import { useLocation, useNavigate } from 'react-router-dom';
import Log from './../../img/sq.white.png';
import './champs.css';

const Championships = () => {
    const location = useLocation();
    const token = location.state.token;
    const [UpcomingChamps, setUpcomingChamps] = useState([]);
    const [CurrentChamps, setCurrentChamps] = useState([]);
    const [PassedChamps, setPassedChamps] = useState([]);

    const [newChampionship, setNewChampionship] = useState({
        title: "",
        dates: "",
        place: "",
        link: "",
        address: "",
    });

    const navigate = useNavigate();

    const handleBackClick = () => {
        navigate('/user', { state: { token } });
    };

    const handleInputChange = (e) => {
        const { name, value } = e.target;
        setNewChampionship((prevChampionship) => ({
            ...prevChampionship,
            [name]: value,
        }));
    };

    const handleAddChampionship = async () => {
        try {
            const response = await fetch('http://morderboy.ru/api/championshipsmanagment/addchampionship', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                    Authorization: `Bearer ${token}`,
                },
                body: JSON.stringify(newChampionship),
            });

            if (response.ok) {
                console.log('Championship added successfully');
            } else if (response.status === 400) {
                throw new Error('Championship already exists in the database');
            } else if (response.status === 500) {
                throw new Error('Internal Server Error');
            } else {
                throw new Error('Error occurred while adding championship');
            }
        } catch (error) {
            console.error(error);
        }
    };

    useEffect(() => {
        const fetchUpcomingChamps = async () => {
            try {
                const response = await fetch('http://morderboy.ru/api/championships/championates/upcoming', {
                    headers: {
                        Authorization: `Bearer ${token}`
                    }
                });
                if (response.ok) {
                    const data = await response.json();
                    setUpcomingChamps(data);
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

        const fetchCurrentChamps = async () => {
            try {
                const response = await fetch('http://morderboy.ru/api/championships/championates/current', {
                    headers: {
                        Authorization: `Bearer ${token}`
                    }
                });
                if (response.ok) {
                    const data = await response.json();
                    setCurrentChamps(data);
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

        const fetchPassedChamps = async () => {
            try {
                const response = await fetch('http://morderboy.ru/api/championships/championates/passed', {
                    headers: {
                        Authorization: `Bearer ${token}`
                    }
                });
                if (response.ok) {
                    const data = await response.json();
                    setPassedChamps(data);
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


        fetchUpcomingChamps();
        fetchCurrentChamps();
        fetchPassedChamps();
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

            <div className='add_championship_block'>
                <h1>Добавить чемпионат</h1>
                <label>Название:</label>
                <input type='text' name='title' value={newChampionship.title} onChange={handleInputChange} />

                <label>Даты:</label>
                <input type='text' name='dates' value={newChampionship.dates} onChange={handleInputChange} />

                <label>Местоположение:</label>
                <input type='text' name='place' value={newChampionship.place} onChange={handleInputChange} />

                <label>Ссылка:</label>
                <input type='text' name='link' value={newChampionship.link} onChange={handleInputChange} />

                <label>Адрес:</label>
                <input type='text' name='address' value={newChampionship.address} onChange={handleInputChange} />

                <button onClick={handleAddChampionship}>Добавить чемпионат</button>
            </div>

            <h1 id='title1'>Управление чемпионатами</h1>
            <div className='info-block3'>
                <h1>Предстоящие</h1>
                {UpcomingChamps.map(champ => (
                    <div key={champ.id} className='info1'>
                        <p>Название: {champ.Title || ""}</p>
                        <p>ID: {champ.Id || ""}</p>
                        <p>Даты: {champ.Dates || ""}</p>
                        <p>Количество участников: {champ.Members_count || ""}</p>
                        <p>Адрес: {champ.Adress || ""}</p>
                        <p>Местоположение: {champ.Place || ""}</p>
                    </div>
                ))}
            </div>

            <div className='info-block3'>
                <h1>Текущие</h1>
                {CurrentChamps.map(champ => (
                    <div key={champ.id} className='info1'>
                        <p>Название: {champ.Title || ""}</p>
                        <p>ID: {champ.Id || ""}</p>
                        <p>Даты: {champ.Dates || ""}</p>
                        <p>Количество участников: {champ.Members_count || ""}</p>
                        <p>Адрес: {champ.Adress || ""}</p>
                        <p>Местоположение: {champ.Place || ""}</p>
                    </div>
                ))}
            </div>

            <div className='info-block3'>
                <h1>Прошедшие</h1>
                {PassedChamps.map(champ => (
                    <div key={champ.id} className='info1'>
                        <p>Название: {champ.Title || ""}</p>
                        <p>ID: {champ.Id || ""}</p>
                        <p>Даты: {champ.Dates || ""}</p>
                        <p>Количество участников: {champ.Members_count || ""}</p>
                        <p>Адрес: {champ.Adress || ""}</p>
                        <p>Местоположение: {champ.Place || ""}</p>
                    </div>
                ))}
            </div>

        </div>
    );
}

export default Championships;