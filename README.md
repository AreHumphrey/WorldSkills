# WorldSkills
<div>
Ко всем api отправляется JSON-file с данными
</div>

# Login
<div>
<p>http://serverip/api/login</p>
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
<p>http://serverip/api/registration</p>
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
