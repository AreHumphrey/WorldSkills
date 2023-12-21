import React, { useEffect, useState } from "react";
import { useLocation, useNavigate } from "react-router-dom";
import Log from "./../../img/sq.white.png";
import Log1 from "./../../img/user.jpg";
import Log2 from "./../../img/aaa.png";
import "./mycomp.css";

const Mycomp = () => {
  const location = useLocation();
  const token = location.state.token;

  const navigate = useNavigate();

  const [competence, setCompetence] = useState("");
  const [championshipId, setChampionshipId] = useState("");
  const [selectedCategory, setSelectedCategory] = useState("");
  const [displayData, setDisplayData] = useState([]);
  const [planLink, setPlanLink] = useState("");
  const [smpLink, setSmpLink] = useState("");
  const [infrastructureLink, setInfrastructureLink] = useState("");

  useEffect(() => {
    fetch("http://morderboy.ru/api/userchampionship", {
      method: "GET",
      headers: {
        Authorization: `Bearer ${token}`,
      },
    })
      .then((response) => response.json())
      .then((data) => {
        if (data.CompetenceId) {
          setCompetence(data.CompetenceId);
        }
        if (data.ChampionshipId) {
          setChampionshipId(data.ChampionshipId);
        }
      })
      .catch((error) => {
        console.error("Error:", error);
      });
  }, [token]);

  const handleBackClick = () => {
    navigate("/user", { state: { token } });
  };

  const handleCategoryClick = async (category) => {
    setSelectedCategory(category);

    if (category === "plan") {
      setDisplayData([]);
      try {
        const response = await fetch(
          `http://morderboy.ru/api/championships/link/${championshipId}`,
          {
            method: "GET",
            headers: {
              Authorization: `Bearer ${token}`,
            },
          }
        );

        const data = await response.text();

        if (data) {
          setPlanLink(data);
        } else {
          setPlanLink("");
        }
      } catch (error) {
        console.error("Error:", error);
      }
    } else if (category === "smp") {
      setDisplayData([]);
      fetchSmpFile();
    } else if (category === "infrastructure") {
        setDisplayData([]);
        fetchInfrastructureFile();
    } else {
      setPlanLink("");
      setSmpLink("");
      try {
        const response = await fetch(
          `http://morderboy.ru/api/champcompetence/${category}/${championshipId}&${competence}`,
          {
            method: "GET",
            headers: {
              Authorization: `Bearer ${token}`,
            },
          }
        );

        const data = await response.json();

        if (data.length > 0) {
          // Display the fetched information
          setDisplayData(data);
        } else {
          // Handle case when no data is available for the selected category
          setDisplayData([]);
        }
      } catch (error) {
        console.error("Error:", error);
      }
    }
  };

  const fetchSmpFile = async () => {
    try {
      const response = await fetch(
        `http://morderboy.ru/api/files/SMP/Download/${championshipId}&${competence}`,
        {
          method: "GET",
          responseType: 'blob',
          headers: {
            Authorization: `Bearer ${token}`,
          },
        }
      );

      if (response.status === 200) {
        const blob = await response.blob();
        const smpUrl = URL.createObjectURL(blob);
        
        setSmpLink(smpUrl);
      } else {
        console.error("Файл SMP не найден");
      }
    } catch (error) {
      console.error("Error:", error);
    }
  };
  const fetchInfrastructureFile = async () => {
    try {
      const response = await fetch(
        `http://morderboy.ru/api/files/Infrastructure/Download/${championshipId}&${competence}`,
        {
          method: "GET",
          responseType: 'blob',
          headers: {
            Authorization: `Bearer ${token}`,
          },
        }
      );

      if (response.status === 200) {
        const blob = await response.blob();
        const infrastructureUrl = URL.createObjectURL(blob);
        
        setInfrastructureLink(infrastructureUrl);
      } else {
        console.error("Файл Infrastructure не найден");
      }
    } catch (error) {
      console.error("Error:", error);
    }
  };

  return (
    <div className="container_profile1">
      <div className="user_row1">
        <div className="user_logo1">
          <img src={Log} alt="Logo" />
        </div>
        <h1>WorldSkills Russia</h1>
        <button onClick={handleBackClick}>Назад</button>
      </div>
      <div className="comp">
        <p>Компетенция: {competence}</p>
        {championshipId && <p1>Соревнование: {championshipId}</p1>}
      </div>
      <div className="category_container">
        <button
          className={selectedCategory === "users" ? "selected" : ""}
          onClick={() => handleCategoryClick("users")}
        >
          Участники
        </button>
        <button
          className={selectedCategory === "experts" ? "selected" : ""}
          onClick={() => handleCategoryClick("experts")}
        >
          Эксперты
        </button>
        <button
          className={selectedCategory === "plan" ? "selected" : ""}
          onClick={() => handleCategoryClick("plan")}
        >
          План Застройки
        </button>
        <button
          className={selectedCategory === "smp" ? "selected" : ""}
          onClick={() => handleCategoryClick("smp")}
        >
          Download SMP
        </button>
        <button
          className={selectedCategory === "infrastructure" ? "selected" : ""}
          onClick={() => handleCategoryClick("infrastructure")}
        >
          Инфраструктура
        </button>
      </div>
      <div className="display_container">
        {selectedCategory === "plan" && planLink && (
          <div className="plan-link">
            <img src={Log2} alt="geo" />
            <a href={planLink} target="_blank" rel="noreferrer">
              Открыть План
            </a>
          </div>
        )}
        {selectedCategory === "smp" && smpLink && (
          <div className="smp-link">
            <p>SMP File:</p>
            <a href={smpLink} download="smp.pdf">
              Скачать SMP
            </a>
          </div>
        )}
        {selectedCategory === "infrastructure" && infrastructureLink && (
          <div className="infrastructure-link">
            <p>Infrastructure File:</p>
            <a href={infrastructureLink} download="infrastructure.xlsx">
              Скачать Инфраструктуру
            </a>
          </div>
        )}
        {displayData.length > 0 && selectedCategory !== "smp" ? (
        <ul>
            {displayData.map((item, index) => (
            <li key={index} className="blant">
                <img src={Log1} alt="user" />
                <p>Имя: {item.FirstName}</p>
                <p>Фамилия: {item.LastName}</p>
                <p>Пол: {item.Gender}</p>
                <p>Регион: {item.Regionname}</p>
            </li>
            ))}
        </ul>
        ) : (
        <>
            {selectedCategory !== "plan" && selectedCategory !== "smp" && selectedCategory !== "infrastructure" && displayData.length === 0 && (
            <p>Не найдено ни одного {selectedCategory.toLowerCase()}</p>
            )}
        </>
        )}
    </div>
</div>
);
};

export default Mycomp;