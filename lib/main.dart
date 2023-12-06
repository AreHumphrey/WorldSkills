import 'package:flutter/material.dart';
import 'package:flutter/rendering.dart';
import 'bottom_nav_bar.dart';
import 'package:http/http.dart' as http;
import 'dart:convert';

import 'package:flutter/material.dart';

class CustomButtonLogin extends StatelessWidget {
  final VoidCallback onPressed;
  final String text;

  const CustomButtonLogin({
    Key? key,
    required this.onPressed,
    required this.text,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Container(
      width: 390.16553,
      height: 50.31846,
      decoration: BoxDecoration(
        color: const Color(0xFF003764),
        borderRadius: BorderRadius.circular(29.68789),
      ),
      child: ElevatedButton(
        onPressed: onPressed,
        child: Text(
          text,
          style: TextStyle(
            color: Colors.white,
            fontSize: 16,
          ),
        ),
        style: ElevatedButton.styleFrom(
          primary: Colors.transparent,
          onPrimary: Colors.transparent,
          onSurface: Colors.transparent,
          shadowColor: Colors.transparent,
          shape: RoundedRectangleBorder(
            borderRadius: BorderRadius.circular(29.68789),
          ),
        ),
      ),
    );
  }
}

class CustomButtonRegistration extends StatelessWidget {
  final VoidCallback onPressed;
  final String text;

  const CustomButtonRegistration({
    Key? key,
    required this.onPressed,
    required this.text,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Container(
      width: 390.16553,
      height: 50.31846,
      decoration: BoxDecoration(
        color: const Color(0xFFB0183D),
        borderRadius: BorderRadius.circular(29.68789),
      ),
      child: ElevatedButton(
        onPressed: onPressed,
        child: Text(
          text,
          style: TextStyle(
            color: Colors.white,
            fontSize: 18,
          ),
        ),
        style: ElevatedButton.styleFrom(
          primary: Colors.transparent,
          onPrimary: Colors.transparent,
          onSurface: Colors.transparent,
          shadowColor: Colors.transparent,
          shape: RoundedRectangleBorder(
            borderRadius: BorderRadius.circular(29.68789),
          ),
        ),
      ),
    );
  }
}
void main() {
  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'flutterflux.com',
      theme: ThemeData(
        backgroundColor: Color(0xFFE5E9EA),
        primaryColor: Colors.deepPurple,
        colorScheme: ColorScheme.fromSwatch(),
        scaffoldBackgroundColor: Color(0xFFE5E9EA),
        appBarTheme: AppBarTheme(
          color: Color(0xFFE5E9EA),
        ),
        textTheme: TextTheme(
          displayLarge: TextStyle(
            color: Colors.black,
            fontSize: 24,
            fontWeight: FontWeight.bold,
          ),
          bodyLarge: TextStyle(
            color: Colors.black,
            fontSize: 16,
            fontWeight: FontWeight.normal,
          ),
        ),
        inputDecorationTheme: InputDecorationTheme(
          focusedBorder: UnderlineInputBorder(
            borderSide: BorderSide(color: Colors.grey[800]!),
          ),
          enabledBorder: UnderlineInputBorder(
            borderSide: BorderSide(color: Colors.grey[800]!),
          ),
        ),
      ),
      home: const LoginScreen(),
    );
  }


}

class LoginScreen extends StatefulWidget {
  const LoginScreen({Key? key}) : super(key: key);

  @override
  _LoginScreenState createState() => _LoginScreenState();
}

class _LoginScreenState extends State<LoginScreen> {
  late String username;
  late String password;

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text(
          'Вход',
          style: TextStyle(fontSize: 24),
        ),
        centerTitle: true,

      ),
      body: SingleChildScrollView(
        padding: const EdgeInsets.all(8.0),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: <Widget>[

            SizedBox(height: 170),
            Container(
              height: 60,
              child: TextFormField(
                style: TextStyle(fontSize: 20),
                decoration: InputDecoration(
                  labelText: 'Логин',
                  prefixIcon: Icon(Icons.person, color: Color(0xFF0084AD)),
                  contentPadding: EdgeInsets.only(left: 20, top: 20, bottom: 20),
                ),
                onChanged: (value) {
                  username = value;
                },
              ),
            ),
            SizedBox(height: 40),
            Container(
              height: 60,
              child: TextFormField(
                style: TextStyle(fontSize: 20),
                decoration: InputDecoration(
                  labelText: 'Пароль',
                  prefixIcon: Icon(Icons.lock, color: Color(0xFF0084AD)),
                  contentPadding: EdgeInsets.only(left: 20, top: 20, bottom: 20),
                ),
                onChanged: (value) {
                  password = value;
                },
              ),
            ),

            SizedBox(height: 72),
            CustomButtonLogin(
              onPressed: () {
                Navigator.push(
                  context,
                  MaterialPageRoute(builder: (context) => BottomNavBar()),
                );
                _loginUser(username, password);
              },
              text: 'Войти',
            ),
            SizedBox(height: 50),
            TextButton(
              onPressed: () {
                Navigator.push(
                  context,
                  MaterialPageRoute(builder: (context) => RegistrationScreen()),
                );
              },
              style: ButtonStyle(
                overlayColor: MaterialStateProperty.all(Colors.transparent),
              ),
              child: Center(
                child: Text(
                  'Нет аккаунта? Зарегистрируйтесь!',
                  style: TextStyle(
                    fontSize: 16,
                    fontWeight: FontWeight.bold,
                    color: Color(0xFF383838)
                  ),
                ),
              ),
            ),

          ],
        ),
      ),
    );
  }


  Future<void> _loginUser(String username, String password) async {

    String? result = await ApiService.loginUser(username, password);
    if (result != null) {
      Navigator.pushReplacement(
        context,
        MaterialPageRoute(builder: (context) => BottomNavBar()),
      );
    } else {
      Navigator.pushReplacement(
        context,
        MaterialPageRoute(builder: (context) => BottomNavBar()),
      );
    }

  }
}

class RegistrationScreen extends StatefulWidget {
  const RegistrationScreen({Key? key}) : super(key: key);

  @override
  _RegistrationScreenState createState() => _RegistrationScreenState();
}

class _RegistrationScreenState extends State<RegistrationScreen> {
  late String username;
  late String password;
  late String firstName;
  late String lastName;
  late String gender = '';
  late String region = '';
  late String birthday = '';
  late String selectedGender = '';

  void selectGender(String selectedGender) {
    setState(() {
      gender = selectedGender;
    });
  }

  Future<void> selectDate(BuildContext context) async {
    final DateTime? picked = await showDatePicker(
      context: context,
      initialDate: DateTime.now(),
      firstDate: DateTime(1900),
      lastDate: DateTime.now(),
    );
    if (picked != null) {
      setState(() {
        birthday = picked.toString();
      });
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text(
          'Регистрация',
          style: TextStyle(fontSize: 24),
        ),
        centerTitle: true,
      ),
      body:SingleChildScrollView(
        padding: const EdgeInsets.all(16.0),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: <Widget>[

            SizedBox(height: 20),
            TextFormField(
              decoration: InputDecoration(labelText: 'Логин'),
              onChanged: (value) {
                username = value;
              },
            ),
            SizedBox(height: 20),
            TextFormField(
              decoration: InputDecoration(labelText: 'Имя'),
              onChanged: (value) {
                username = value;
              },
            ),
            SizedBox(height: 20),
            TextFormField(
              decoration: InputDecoration(labelText: 'Фамилия'),
              onChanged: (value) {
                username = value;
              },
            ),
            SizedBox(height: 50),


            Row(
              children: [
                Text(
                  'Пол: ',
                  style: TextStyle(fontSize: 16),
                ),
                SizedBox(width: 20),
                GestureDetector(
                  onTap: () => selectGender('male'),
                  child: Container(
                    width: 20,
                    height: 20,
                    decoration: BoxDecoration(
                      shape: BoxShape.circle,
                      color: gender == 'male' ? Color(0xFF0084AD) : Colors.white, // Цвет при выборе и изначальный цвет
                      border: Border.all(color: gender == 'male' ? Colors.transparent : Colors.black), // Установка прозрачной обводки при выборе
                    ),
                  ),
                ),
                SizedBox(width: 20),
                Text(
                  'Муж',
                  style: TextStyle(fontSize: 16),
                ),
                SizedBox(width: 20),
                GestureDetector(
                  onTap: () => selectGender('female'),
                  child: Container(
                    width: 20,
                    height: 20,
                    decoration: BoxDecoration(
                      shape: BoxShape.circle,
                      color: gender == 'female' ? Color(0xFF0084AD) : Colors.white,
                      border: Border.all(color: gender == 'female' ? Colors.transparent : Colors.black),
                    ),
                  ),
                ),
                SizedBox(width: 20),
                Text(
                  'Жен',
                  style: TextStyle(fontSize: 1),
                ),
              ],
            ),

            SizedBox(height: 20),
            TextField(
              decoration: InputDecoration(labelText: 'Дата рождения'),
              readOnly: true,
              controller: TextEditingController(text: birthday),
              onTap: () async {
                final DateTime? picked = await showDatePicker(
                  context: context,
                  initialDate: DateTime.now(),
                  firstDate: DateTime(1900),
                  lastDate: DateTime.now(),
                );
                if (picked != null) {
                  setState(() {
                    birthday = picked.toString();
                  });
                }
              },
            ),

            SizedBox(height: 20),
            TextFormField(
              decoration: InputDecoration(labelText: 'Регион'),
              onChanged: (value) {
                region = value;
              },
            ),
            SizedBox(height: 20),
            TextFormField(
              decoration: InputDecoration(labelText: 'Пароль'),
              onChanged: (value) {
                password = value;
              },
            ),
            SizedBox(height: 40),

            CustomButtonRegistration(
              onPressed: () {

                Navigator.push(
                  context,
                  MaterialPageRoute(builder: (context) => BottomNavBar()),
                );
                _registerUser();
              },
              text: 'Зарегистрироваться',
            )
          ],
        ),
      ),
    );
  }

  Future<void> _registerUser() async {
    String? result = await ApiService.registerUser(
        username, password, firstName, lastName, gender, birthday, region);
  }
}

class ApiService {
  static Future<String?> registerUser(
      String username,
      String password,
      String firstName,
      String lastName,
      String gender,
      String birthday,
      String region) async {
    final String apiUrl = 'http://serverip/api/registration';
    final response = await http.post(
      Uri.parse(apiUrl),
      headers: <String, String>{
        'Content-Type': 'application/json; charset=UTF-8',
      },
      body: jsonEncode(<String, String>{
        'username': username,
        'password': password,
        'firstName': firstName,
        'lastName': lastName,
        'gender': gender,
        'birthday': birthday,
        'region': region
      }),
    );

    if (response.statusCode == 200) {
      return 'Ok';
    } else {
      return 'BadRequest';
    }
  }

  static Future<String?> loginUser(String username, String password) async {
    final String apiUrl = 'http://serverip/api/login';
    final response = await http.post(
      Uri.parse(apiUrl),
      headers: <String, String>{
        'Content-Type': 'application/json; charset=UTF-8',
      },
      body: jsonEncode(<String, String>{
        'username': username,
        'password': password,
      }),
    );

    if (response.statusCode == 200) {
      var jsonResponse = json.decode(response.body);
      String token = jsonResponse['token'];
      return token;
    } else {
      return 'NotFound';
    }
  }
}
