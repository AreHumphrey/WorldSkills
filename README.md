# WorldSkills
<div>
Ко всем api отправляется JSON-file с данными
</div>

# Login
<div>
<p>http://morderboy.ru/api/login</p>
<p>
Сюда неоходимо отослать 
  {
  "username": "string",
  "password": "string"
  }
</p>
<p>Если получили в ответ Ok, то вход выполнен и в ответ вы получите персональный token юзера который дальше будет использоваться как аутентификатор</p>
<p>Если получили NotFound, то пользователь не найден в базе данных</p>
</div>

# Registration
<div> 
<p>http://morderboy.ru/api/registration</p>
<p>
Сюда неоходимо отослать
  {
    "username": "string",
    "password": "string",
    "firstName": "string",
    "lastName": "string",
    "gender": "string",
    "birthday": "string",
    "region": "string"
  }
<p>
<p>Если получили в ответ Ok, то пользователь зарегистрирован</p>
<p>Если получили BadRequest, то это значит, что пользователь с таким логином уже присутствует в базе</p>
</div>

# Секция смены пороля 
<div> 
<h1>Sendcode</h1>
<p>http://morderboy.ru/api/sendcode</p>
<p>
Сюда неоходимо отослать
  { email }
</p>
<p>Если получили в ответ Ok, то пользователь присутсвует в базе данных и ему на почту отпавлен 6 значный код. Код действителен в течении 3 минут 30 секунд</p>
<p>Если получили NotFound, то это значит, что пользователь с такой почтой не зарегестрирован</p>
</div>
<div> 
<h1>Verificode</h1>
<p>http://morderboy.ru/api/verificode</p>
<p>
Сюда неоходимо отослать
  {
    email: "email пользователя введённый в Sendcode"
    code: "код введённый пользователем"
  }
</p>
<p>Если получили в ответ Ok, то код был подтверждён и можно переходить к смене пароля</p>
<p>Если получили BedRequest, то это значит, что код неверный или пользователь не найден</p>
</div>
<div> 
<h1>Changepassword</h1>
<p>http://morderboy.ru/api/сhangepassword</p>
<p>
Сюда неоходимо отослать
  {
    email: "email пользователя введённый в Sendcode"
    password: "новый пороль введённый пользователем"
  }
</p>
<p>Если получили в ответ Ok, то пароль для пользователя обновлён</p>
<p>Если получили BedRequest, то это значит, что пользователь был найден, но обновить для него данные в бд не удалось</p>
<p>Если получили NotFound, то это значит, что пользователь с такой почтой не зарегестрирован</p>
</div>

# UserProfile
<div> 
<h1>GetProfileInfo</h1>
<p>http://morderboy.ru/api/getprofileinfo</p>
<p>
Этот метод типа GET сюда ничего не надо отсылать кроме bearer токена, для подтверждения авторизации пользователя
<p>
<p>Если получили в ответ Ok, то всё ок и вам вернут JSON</p>
<p>
{
    Name: "Имя пользователя",
    Gender: "Пол",
    IdNumber: "ID пользователя в бд",
    Region: "Город",
    Area: "Название региона"
};
</p>
<p>Если получили NotFound("У пользователя нет claims"), это значит, что куки пользователя не найдены на сервере</p>
<p>Если получили NotFound, то это значит, что пользователь не найден</p>
</div>

# Getname
<div> 
<h1>GetName</h1>
<p>http://morderboy.ru/api/getname</p>
<p>
Этот метод типа GET сюда ничего не надо отсылать кроме bearer токена, для подтверждения авторизации пользователя
<p>
<p>Если получили в ответ Ok, то всё ок и вам вернут json</p>
<p>
{
  name: "Имя пользователя",
  surname: "Фамилия ппользователя",
  gender: "Пол пользователя (Male|Female)"
}
</p>
<p>Если получили NotFound("У пользователя нет claims"), это значит, что куки пользователя не найдены на сервере</p>
</div>

# Getresults
<div> 
<h1>GetResults</h1>
<p>http://morderboy.ru/api/getresults</p>
<p>
Этот метод типа GET сюда ничего не надо отсылать кроме bearer токена, для подтверждения авторизации пользователя
<p>
<p>Если получили в ответ Ok, то всё ок и вам вернут json</p>
<p>Это пример json который сервер вам может вернуть в ответ</p>
<p>
{
  "Result 1": {
    "ChampName": "Champ 2",
    "Competence": 1,
    "ParticipantID": "c46b53c1-19d1-48c1-bbab-de92bd1dcbbf",
    "Module": "10, 10",
    "Grade": 20.0
  },
  "Result 2": {
    "ChampName": "Champ 3",
    "Competence": 2,
    "ParticipantID": "c46b53c1-19d1-48c1-bbab-de92bd1dcbbf",
    "Module": "5, 5, 10, 2, 8",
    "Grade": 30.0
  }
}
</p>
<p>Как видно из данного примера вам вернут все результаты пользователя по каждому Модулю для каждого Соревнования</p>
<p>Чисто гипотетически их может быть сколь угодно много, также для одного соревнования может быть несколько модулей</p>
<p>Если получили NotFound("У пользователя нет claims"), это значит, что куки пользователя не найдены на сервере</p>
<p>Если получили NotFound("Для пользователя не найден email"), это значит, что куки пользователя не содержат его email</p>
<p>Если получили NotFound("Пользователь не найден"), это значит, что рользователь не найден в базе данных</p>
<p>Если получили NotFound("У пользователя нет результатов"), это значит, что для пользователя не найдены результаты</p>
</div>

# UserChampionship
<div>
<p>http://morderboy.ru/api/userchampionship</p>
<p>Ok() Вернёт следующий JSON</p>
<div>
{
  "ChampionshipId": "Id соревнования int",
  "CompetenceId": "Код компетенции string"
}
</div>
<p>BadRequest("Данное api рассчитано на обычных пользователей") если роль ванего юзера не U</p>
<p>BadRequest("Токен повреждён пожалуйста войдите в систему повторно")</p>
<p>return NotFound("Пользователь с такой почтой не найден в системе")</p>
<p>BadRequest("Пользователь не участвует не в одном чемпионате")</p>
</div>

# ChampCompetenceExperts
<div>
<p>http://morderboy.ru/api/champcompetence/experts/{ChampionshipId}&{CompetenceId}</p>
<p>Вот пример того какой адрес нужно передавать для url запроса</p>
<p>http://morderboy.ru/api/champcompetence/experts/1&RU</p>
<p>Здесь ChampionshipId = 1 и CompetenceId = RU их нужно передавать разделяя &</p>
<p>Ok() Вернёт следующий список JSON-ов</p>
<div>
[
  {
    "FirstName": "Имя",
    "LastName": "Фамилия",
    "Gender": "Пол",
    "Regionname": "Регион (По факту город)"
  }
]
</div>
<p>Как видно по квадратным [] скобочкам это список из JSON-ов содержащих давнный для всех эспертов для данного чемпионата в данной компетенции</p>
<p>NotFound("Не найдено ни одного эксперта") для данного соревнования для данной компетенции нет ни одного эксперта</p>
</div>

# ChampCompetenceUsers
<div>
<p>http://morderboy.ru/api/champcompetence/users/{ChampionshipId}&{CompetenceId}</p>
<p>Вот пример того какой адрес нужно передавать для url запроса</p>
<p>http://morderboy.ru/api/champcompetence/users/1&RU</p>
<p>Здесь ChampionshipId = 1 и CompetenceId = RU их нужно передавать разделяя &</p>
<p>Ok() Вернёт следующий список JSON-ов</p>
<div>
[
  {
    "FirstName": "Имя",
    "LastName": "Фамилия",
    "Gender": "Пол",
    "Regionname": "Регион (По факту город)"
  }
]
</div>
<p>Как видно по квадратным [] скобочкам это список из JSON-ов содержащих давнный для всех эспертов для данного чемпионата в данной компетенции</p>
<p>NotFound("Не найдено ни одного участника") для данного соревнования для данной компетенции нет ни одного участника</p>
</div>

# ChampionshipLink
<div>
<p>http://morderboy.ru/api/championships/link/{champId}</p>
<p>Вот пример того какой адрес нужно передавать для url запроса</p>
<p>http://morderboy.ru/api/championships/link/1</p>
<p>Здесь ChampId = 1, ChampId это Id соревнования</p>
<p>Ok() Вернёт вам геоссылку на яндекс карту в формате string</p>
<div>
https://yandex.ru/maps/?text=%d0%baA%2c+%d0%bf%d0%be%d1%81%d1%91%d0%bb%d0%be%d0%ba+%d0%90%d1%8f%d0%ba%d1%81%2c+%d0%ba%d0%b0%d0%bc%d0%bf%d1%83%d1%81+%d0%94%d0%b0%d0%bb%d1%8c%d0%bd%d0%b5%d0%b2%d0%be%d1%81%d1%82%d0%be%d1%87%d0%bd%d0%be%d0%b3%d0%be+%d1%84%d0%b5%d0%b4%d0%b5%d1%80%d0%b0%d0%bb%d1%8c%d0%bd%d0%be%d0%b3%d0%be+%d1%83%d0%bd%d0%b8%d0%b2%d0%b5%d1%80%d1%81%d0%b8%d1%82%d0%b5%d1%82%d0%b0%2c+%d0%bf%d0%be%d1%81%d1%91%d0%bb%d0%be%d0%ba+%d0%a0%d1%83%d1%81%d1%81%d0%ba%d0%b8%d0%b9
</div>
<p>NotFound("Неправильный id чемпионата") чемпионат не найден в бд</p>
<p>BadRequest("Адрес не найден") у данного чемпионата отсутствует адресс</p>
</div>