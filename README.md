# WorldSkills
<div>
Ко всем api отправляется JSON-file с данными
</div>
# Login
<div>
http://serverip/api/login
Сюда неоходимо отослать 
  {
  "username": "string",
  "password": "string"
  }
Если получили в ответ Ok, то вход выполнен и в ответ вы получите персональный token юзера который дальше будет использоваться как аутентификатор
Если получили NotFound, то пользователь не найден в базе данных
</div>

# Registration
<div> 
http://serverip/api/registration
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
Если получили в ответ Ok, то пользователь зарегистрирован
Если получили BadRequest, то это значит, что пользователь с таким логином уже присутствует в базе
</div>
