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
<p>http://morderboy.ru/api/getprofile</p>
<p>
Этот метод типа GET сюда ничего не надо отсылать кроме bearer токена, для подтверждения авторизации пользователя
<p>
<p>Если получили в ответ Ok, то всё ок и вам вернут JSON</p>
<p>
{
    Name: "Имя пользователя полное",
    Gender: "Пол",
    IdNumber: "ID пользователя в бд",
    Region: "Город",
    Area: "Название региона"
};
</p>
<p>Если получили NotFound("У пользователя нет claims"), это значит, что куки пользователя не найдены на сервере</p>
<p>Если получили NotFound, то это значит, что пользователь не найден</p>
</div>

<div> 
<h1>GetProfileInfo</h1>
<p>http://morderboy.ru/api/getprofile/getrole</p>
<p>
Этот метод типа GET сюда ничего не надо отсылать кроме bearer токена, для подтверждения авторизации пользователя
<p>
<p>Если получили в ответ Ok, то всё ок и вам вернут строку с названием роли</p>
<p>
"U"
</p>
<p>Если получили NotFound("У пользователя нет claims"), это значит, что куки пользователя не найдены на сервере</p>
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

# Championship
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

# Championhips
<h1>Upcoming<h1>
<div>
<p>http://morderboy.ru/api/championships/championates/upcoming</p>
<p>Нужна авторизация</p>
<p>Ok() Вернёт вам список чемпионатов которые только предстоят</p>
<div>
[
  {
    "Id": 1,
    "Members_count": 900,
    "Title": "Champ 1",
    "Dates": "2023-12-17T00:00:00",
    "Place": "Place",
    "Link": "Link",
    "Adress": "кA, посёлок Аякс, кампус Дальневосточного федерального университета, посёлок Русский"
  }
]
<div>
</div>
</n>
<h1>Current<h1>
<div>
<p>http://morderboy.ru/api/championships/championates/current</p>
<p>Нужна авторизация</p>
<p>Ok() Вернёт вам список чемпионатов которые идут в данный момент</p>
<div>
[
  {
    "Id": 1,
    "Members_count": 900,
    "Title": "Champ 1",
    "Dates": "2023-12-17T00:00:00",
    "Place": "Place",
    "Link": "Link",
    "Adress": "кA, посёлок Аякс, кампус Дальневосточного федерального университета, посёлок Русский"
  }
]
<div>
</div>
</n>
<h1>passed<h1>
<div>
<p>http://morderboy.ru/api/championships/championates/passed</p>
<p>Нужна авторизация</p>
<p>Ok() Вернёт вам список чемпионатов которые уже прошли</p>
<div>
[
  {
    "Id": 1,
    "Members_count": 900,
    "Title": "Champ 1",
    "Dates": "2023-12-17T00:00:00",
    "Place": "Place",
    "Link": "Link",
    "Adress": "кA, посёлок Аякс, кампус Дальневосточного федерального университета, посёлок Русский"
  }
]
<div>
</div>
</n>
<h1>Get Competences<h1>
<div>
<p>http://morderboy.ru/api/Championships/championates/getcompetences/{champId}</p>
<p>Нужна авторизация</p>
<p>champId - Id чемпионата компетенции которого хотите получить</p>
<p>Ok() Вернёт вам список компетенций чемпионата</p>
<div>
[
  {
    "Code": "RU",
    "Name": "Ru lang",
    "Description": "Description"
  },
  {
    "Code": "MS",
    "Name": "Math statistics",
    "Description": "Description"
  }
]
<div>
</div>

# ChampionshipsManagment
<h1>Add Championship<h1>
<div>
<p>Это метод POST</p>
<p>http://morderboy.ru/api/championshipsmanagment/addchampionship</p>
<p>Нужна авторизация от Админа</p>
<p>Ok() если удалось добавить чемпионат</p>
<div>
{
  "title": "Champ 5",
  "dates": "2023-12-18T14:36:40.127Z",
  "place": "Place",
  "link": "link",
  "adress": "adress"
}
<div>
<p>BadRequest("Такой чемпионат уже есть в базе")</p>
<p>StatusCode(500, "Internal Server Error") вернёт статус код 500 если не удолось обновить бд. Для ошибки 500 необходимо просто выводить "Internal Server Error" и ничего более!!!!</p>
</div>

# Смена почты и имени
<h1>Change email<h1>
<div>
<p>Это метод PATCH</p>
<p>http://morderboy.ru/api/changeemail</p>
<p>Нужна авторизация</p>
<p>Ok() если удалось сменить почту</p>
<div>
{"email"} - отправить сюда
<div>
<p>NotFound("Пользователь не найден в системе")</p>
<p>StatusCode(500, "Internal Server Error") вернёт статус код 500 если не удолось обновить бд. Для ошибки 500 необходимо просто выводить "Internal Server Error" и ничего более!!!!</p>
</div>
<h1>Change name<h1>
<div>
<p>Это метод PATCH</p>
<p>http://morderboy.ru/api/changename</p>
<p>Нужна авторизация</p>
<p>Ok() если удалось сменить имя</p>
<div>
{
    "firstname": "Артём",
    "lastname": "Быков"
}
<div>
<p>NotFound("Пользователь не найден в системе")</p>
<p>StatusCode(500, "Internal Server Error") вернёт статус код 500 если не удолось обновить бд. Для ошибки 500 необходимо просто выводить "Internal Server Error" и ничего более!!!!</p>
</div>

# UserManagment
<h1>Add user to championate to competence<h1>
<div>
<p>Это метод PUT</p>
<p>http://morderboy.ru/api/usermanagment</p>
<p>Нужна авторизация от Админа</p>
<p>Ok() удалось добавить пользователя на чемпионат на компетенцию</p>
<div>
{
  "email": "dindindina@gmail.com",
  "champId": 4,
  "compCode": "CS"
}
<div>
<p>NotFound("Пользователь не найден в базе")</p>
<p>BadRequest("Чемпионат уже окончен")</p>
<p>BadRequest("Чемпионат не содержит компетенции с таким кодом")</p>
<p>StatusCode(500, "Internal Server Error") вернёт статус код 500 если не удолось обновить бд. Для ошибки 500 необходимо просто выводить "Internal Server Error" и ничего более!!!!</p>
</div>
<h1>Get list of users<h1>
<div>
<p>Это метод GET</p>
<p>http://morderboy.ru/api/usermanagment</p>
<p>Нужна авторизация от Админа</p>
<p>Ok() Спрсок всех пользователей</p>
<div>
[
  {
    "RoleName": "A",
    "Email": "slava137267@gmail.com",
    "Name": "Слава Трегубов",
    "Gender": "Male",
    "IdNumber": "7fe28520-d3ef-4fba-a459-f3d4637d8f50",
    "Region": "Name",
    "Area": "RF"
  }
]
<div>
<p>NotFound("Ни одного пользователя не найдено в системе")</p>
</div>

# ExpertManagment
<h1>Get experts list<h1>
<div>
<p>Это метод Get</p>
<p>http://morderboy.ru/api/expertmanagment</p>
<p>Нужна авторизация от Админа</p>
<p>Ok() вам вернут список экспертов</p>
<div>
[
  {
    "id":"885d00d0-97b7-4e2c-a4f3-cad78aec7aee",
    "username":"chert@gmail.com",
    "birthday":"4/3/2001 12:00:00AM",
    "regioncode":"RF",
    "firstName":"F",
    "lastName":"L",
    "gender":"Male",
    "regionname":"Name"
  },
  {
    "id":"b3147b0e-c73d-4d34-b413-c69cf4381226",
    "username":"abobus@gmail.com",
    "birthday":"4/3/2001 12:00:00AM",
    "regioncode":"RF",
    "firstName":"F",
    "lastName":"L",
    "gender":"Male",
    "regionname":"Name"
  }
]
<div>
</div>
<h1>Delete expert (Ещё не доработано ни в коме случае не использовать!!!!!!)<h1>
<div>
<p>Это метод DELETE</p>
<p>http://morderboy.ru/api/expertmanagment</p>
<p>Нужна авторизация от Админа</p>
<p>Ok() если эксперт был успешно удалён</p>
<div>
["id1", "id2"] - сюда необходимо передавать список id для удаления
<div>
</div>
</div>
<h1>Add to Experts<h1>
<div>
<p>Это метод PATCH</p>
<p>http://morderboy.ru/api/expertmanagment/addtoexperts</p>
<p>Нужна авторизация от Админа</p>
<p>Ok() всем пользователям были разданы роли экспертов</p>
<div>
["id1", "id2"] - сюда необходимо передавать список id для удаления
<div>
<p>BadRequest("Неправильный id: " + id)</p>
<p>StatusCode(500, "Internail server errror") ошибка в бд</p>
<p>StatusCode(500, "Internail server errror on user with id: " + id)</p>
</div>