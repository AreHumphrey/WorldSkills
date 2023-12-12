import 'package:flutter/material.dart';
import 'package:flutter/rendering.dart';
import 'bottom_nav_bar.dart';
import 'package:http/http.dart' as http;
import 'dart:convert';
import 'package:flutter_svg/flutter_svg.dart';
import 'widgets/CustomButtonLogin_w.dart';
import 'widgets/CustomButtonRegistration_w.dart';
import 'forgot_password/ForgotPassword.dart';

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
            borderSide: BorderSide(color: Colors.black!),
          ),
          enabledBorder: UnderlineInputBorder(
            borderSide: BorderSide(color: Colors.black!),
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
  late String username = ' ';
  late String password = ' ';
  bool rememberMe = false;

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
            Padding(
              padding: const EdgeInsets.only(top: 0),
              child: Center(
                child: Image.asset(
                  'assets/WS_Logo_DarkBlue_RGB.png',
                  width: 300,
                  height: 300,
                ),
              ),
            ),
            Center(
              child: Container(
                height: 60,
                width: 380,
                child: TextFormField(
                  style: TextStyle(fontSize: 20),
                  decoration: InputDecoration(
                    hintText: 'Логин',
                    hintStyle: TextStyle(fontSize: 20),
                    prefixIcon: Padding(
                      padding: const EdgeInsets.all(15.0),
                      child: SvgPicture.asset(
                        'assets/person.svg',
                        semanticsLabel: 'Person',
                        width: 40,
                        height: 40,
                      ),
                    ),
                    contentPadding:
                        EdgeInsets.only(left: 20, top: 20, bottom: 20),
                    focusedBorder: OutlineInputBorder(
                      borderSide: BorderSide(color: Colors.blue, width: 2.0),
                      borderRadius: BorderRadius.circular(8.0),
                    ),
                    enabledBorder: OutlineInputBorder(
                      borderSide: BorderSide(color: Colors.black, width: 1.0),
                      borderRadius: BorderRadius.circular(8.0),
                    ),
                  ),
                  onChanged: (value) {
                    setState(() {
                      username = value;
                    });
                  },
                ),
              ),
            ),
            SizedBox(height: 40),
            Center(
              child: Container(
                height: 60,
                width: 380,
                child: TextFormField(
                  style: TextStyle(fontSize: 20),
                  decoration: InputDecoration(
                    hintText: 'Пароль',
                    hintStyle: TextStyle(fontSize: 20),
                    prefixIcon: Padding(
                      padding: const EdgeInsets.all(15.0),
                      child: SvgPicture.asset(
                        'assets/paroll.svg',
                        semanticsLabel: 'Password',
                        width: 40,
                        height: 40,
                      ),
                    ),
                    contentPadding:
                        EdgeInsets.only(left: 20, top: 20, bottom: 20),
                    focusedBorder: OutlineInputBorder(
                      borderSide: BorderSide(color: Colors.blue, width: 2.0),
                      borderRadius: BorderRadius.circular(8.0),
                    ),
                    enabledBorder: OutlineInputBorder(
                      borderSide: BorderSide(color: Colors.black, width: 1.0),
                      borderRadius: BorderRadius.circular(8.0),
                    ),
                  ),
                  onChanged: (value) {
                    setState(() {
                      password = value;
                    });
                  },
                ),
              ),
            ),
            SizedBox(height: 40),
            Row(
              mainAxisAlignment: MainAxisAlignment.start,
              children: [
                Row(
                  children: [
                    Checkbox(
                      value: rememberMe,
                      onChanged: (bool? value) {
                        setState(() {
                          rememberMe = value!;
                        });
                      },
                    ),
                    Text('Запомнить меня', style: TextStyle(fontSize: 18)),
                  ],
                ),
                SizedBox(width: 40),
                GestureDetector(
                  onTap: () {
                    Navigator.push(
                      context,
                      MaterialPageRoute(
                          builder: (context) => ForgotPasswordEmailScreen()),
                    );
                  },
                  child: Text(
                    'Забыли пароль?',
                    style: TextStyle(fontSize: 18, color: Colors.blue),
                  ),
                ),
              ],
            ),
            SizedBox(height: 40),
            CustomButtonLogin(
              onPressed: () {
                _loginUser(username, password);
              },
              text: 'Войти',
            ),
            SizedBox(height: 50),
            TextButton(
              onPressed: () {
                Navigator.push(
                  context,
                  MaterialPageRoute(
                      builder: (context) => RegistrationScreen()),
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
                      color: Color(0xFF383838)),
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
    } else {}
  }
}

class RegistrationScreen extends StatefulWidget {
  const RegistrationScreen({Key? key}) : super(key: key);

  @override
  _RegistrationScreenState createState() => _RegistrationScreenState();
}

class _RegistrationScreenState extends State<RegistrationScreen> {
  String? username = ' ';
  String? password = ' ';
  String? firstName = ' ';
  String? lastName = ' ';
  String gender = '';
  String region = '';
  String birthday = '';
  String selectedGender = '';

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
      body: SingleChildScrollView(
        padding: const EdgeInsets.all(16.0),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: <Widget>[
            SizedBox(height: 20),
            TextFormField(
              decoration: InputDecoration(
                labelText: 'Логин',
                labelStyle: TextStyle(fontSize: 18),
              ),
              style: TextStyle(fontSize: 18),
              onChanged: (value) {
                username = value;
              },
            ),
            SizedBox(height: 20),
            TextFormField(
              decoration: InputDecoration(
                labelText: 'Имя',
                labelStyle: TextStyle(fontSize: 18),
              ),
              style: TextStyle(fontSize: 18),
              onChanged: (value) {
                firstName = value;
              },
            ),
            SizedBox(height: 20),
            TextFormField(
              decoration: InputDecoration(
                labelText: 'Фамилия',
                labelStyle: TextStyle(fontSize: 18),
              ),
              style: TextStyle(fontSize: 18),
              onChanged: (value) {
                lastName = value;
              },
            ),
            SizedBox(height: 50),
            Row(
              children: [
                Text(
                  'Пол: ',
                  style: TextStyle(fontSize: 18),
                ),
                SizedBox(width: 20),
                GestureDetector(
                  onTap: () => selectGender('male'),
                  child: Container(
                    width: 20,
                    height: 20,
                    decoration: BoxDecoration(
                      shape: BoxShape.circle,
                      color: gender == 'male'
                          ? Color(0xFF0084AD)
                          : Color(0xFFE5E9EA),
                      border: Border.all(
                          color: gender == 'male'
                              ? Colors.transparent
                              : Colors.black),
                    ),
                  ),
                ),
                SizedBox(width: 20),
                Text(
                  'Муж',
                  style: TextStyle(fontSize: 18),
                ),
                SizedBox(width: 20),
                GestureDetector(
                  onTap: () => selectGender('female'),
                  child: Container(
                    width: 20,
                    height: 20,
                    decoration: BoxDecoration(
                      shape: BoxShape.circle,
                      color: gender == 'female'
                          ? Color(0xFF0084AD)
                          : Color(0xFFE5E9EA),
                      border: Border.all(
                          color: gender == 'female'
                              ? Colors.transparent
                              : Colors.black),
                    ),
                  ),
                ),
                SizedBox(width: 20),
                Text(
                  'Жен',
                  style: TextStyle(fontSize: 18),
                ),
              ],
            ),
            SizedBox(height: 20),
            TextField(
              decoration: InputDecoration(
                labelText: 'День рождения',
                labelStyle: TextStyle(fontSize: 18),
              ),
              style: TextStyle(fontSize: 18),
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
              decoration: InputDecoration(
                labelText: 'Регион',
                labelStyle: TextStyle(fontSize: 18),
                enabledBorder: UnderlineInputBorder(
                  borderSide: BorderSide(color: Colors.black),
                ),
              ),
              style: TextStyle(fontSize: 18),
              onChanged: (value) {
                region = value;
              },
            ),
            SizedBox(height: 20),
            TextFormField(
              decoration: InputDecoration(
                labelText: 'Пароль',
                labelStyle: TextStyle(fontSize: 18),
              ),
              style: TextStyle(fontSize: 18),
              onChanged: (value) {
                password = value;
              },
            ),
            SizedBox(height: 40),
            CustomButtonRegistration(
              onPressed: () {
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
      username!,
      password!,
      firstName!,
      lastName!,
      gender!,
      birthday!,
      region!,
    );

    if (result == 'Ok') {
      Navigator.push(
        context,
        MaterialPageRoute(builder: (context) => BottomNavBar()),
      );
    } else {
      Navigator.pop(context);
    }
  }
}

class ApiService {
  static Future<String> registerUser(
      String username,
      String password,
      String firstName,
      String lastName,
      String gender,
      String birthday,
      String region) async {
    final String apiUrl = 'http://morderboy.ru/api/registration';
    try {
      final response = await http.post(
        Uri.parse(apiUrl),
        headers: <String, String>{
          'Content-Type': 'application/json; charset=UTF-8',
        },
        body: jsonEncode({
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
    } on Exception catch (_) {
      rethrow;
    }
  }

  static Future<String?> loginUser(String username, String password) async {
    final String apiUrl = 'http://morderboy.ru/api/login';
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
