import 'package:flutter/material.dart';
import 'package:flutter_svg/svg.dart';
import 'package:http/http.dart' as http;
import 'package:wordskills/forgot_user_info/forgot_password.dart';
import 'dart:convert';

import 'forgot_user_info/change_email.dart';
import 'forgot_user_info/change_name.dart';
import 'main.dart';


class GlobalUserInfo {
  static final GlobalUserInfo _instance = GlobalUserInfo._internal();

  factory GlobalUserInfo() => _instance;

  GlobalUserInfo._internal();

  String firstName = '';
  String lastName = '';
}

Future<Map<String, String>> getName(String token) async {
  if (!GlobalToken().isTokenValid()) {
    throw Exception("Токен истек или недействителен");
  }

  final url = Uri.parse('http://morderboy.ru/api/getname');

  Map<String, String> headers = {
    'Authorization': 'Bearer $token',
  };

  final response = await http.get(url, headers: headers);

  if (response.statusCode == 200) {
    Map<String, dynamic> data = json.decode(response.body);
    GlobalUserInfo().firstName = data['name'];
    GlobalUserInfo().lastName = data['surname'];
    String gender = data['gender'];

    return {
      'name': GlobalUserInfo().firstName,
      'surname': GlobalUserInfo().lastName,
      'gender': gender,


    };
  } else if (response.statusCode == 404) {
    throw Exception("У пользователя нет claims");
  } else {
    throw Exception("Ошибка при получении имени пользователя: ${response.statusCode}");
  }
}




class ProfilePage extends StatefulWidget {
  @override
  _ProfilePageState createState() => _ProfilePageState();
}

class _ProfilePageState extends State<ProfilePage> {
  String userName = '';
  String userGender = '';

  @override
  void initState() {
    super.initState();
    fetchUserName();
    fetchUserGender();
  }

  Future<void> fetchUserName() async {
    String token = GlobalToken().token;
    try {
      Map<String, String>? userData = await getName(token);
      GlobalUserInfo().firstName = userData['name']!;
      setState(() {
        userName = GlobalUserInfo().firstName;

      });
    } catch (e) {
      print('Error fetching user name: $e');
    }
  }

  Future<void> fetchUserGender() async {
    String token = GlobalToken().token;
    try {
      Map<String, String>? userData = await getName(token);
      String gender = userData['gender']!;
      setState(() {
        userGender = gender;
      });

      if (userGender == 'male' || userGender == 'Male') {
        userGender = 'Mr.';
      } else if (userGender == 'female' || userGender == 'Female') {
        userGender = 'Ms.';
      }

    } catch (e) {
      print('Error fetching user gender: $e');
    }
  }

  @override
  Widget build(BuildContext context) {
    TimeOfDay currentTime = TimeOfDay.now();
    String greeting = '';
    if (currentTime.hour < 12) {
      greeting = 'Доброе утро,';
    } else if (currentTime.hour < 17) {
      greeting = 'Добрый день,';
    } else {
      greeting = 'Добрый вечер,';
    }

    return Scaffold(
      backgroundColor: Color(0xFFF3F3F4),
      body: Center(
        child: Column(
          mainAxisAlignment: MainAxisAlignment.start,
          children: [
            SizedBox(height: 50),
            Center(
              child: Image.asset(
                'assets/icon_bear.png',
                width: 240,
                height: 240,
              ),
            ),


            Text(
              '$greeting\n $userGender $userName',
              style: TextStyle(
                color: Color(0xFF003764),
                fontSize: 35,
                fontWeight: FontWeight.bold,
              ),
              textAlign: TextAlign.center,
            ),

            SizedBox(height: 30),



            Container(
              padding: EdgeInsets.symmetric(horizontal: 20),
              width: 318,
              height: 38,
              decoration: BoxDecoration(
                color: Color(0xFFFFFFFF),
                borderRadius: BorderRadius.all(Radius.circular(10)),
                boxShadow: [
                  BoxShadow(
                    color: Color(0x40000000),
                    blurRadius: 4,
                    offset: Offset(0, 0),
                  ),
                ],
              ),
              child: GestureDetector(
                onTap: () {
                  Navigator.pushReplacement(
                    context,
                    MaterialPageRoute(builder: (context) => ChangeEmail()),
                  );
                },
                child: Row(
                  mainAxisAlignment: MainAxisAlignment.start,
                  children: [
                    SvgPicture.asset(
                      'assets/mail.svg',
                      semanticsLabel: 'Password',
                      width: 23,
                      height: 23,
                    ),
                    SizedBox(width: 20),
                    Text(
                      'Изменить почту',
                      style: TextStyle(
                        color: Color(0xFF555454),
                        fontSize: 18,
                      ),
                    ),
                  ],
                ),
              ),
            ),

            SizedBox(height: 25),

            Container(
              padding: EdgeInsets.symmetric(horizontal: 20),
              width: 318,
              height: 38,
              decoration: BoxDecoration(
                color: Color(0xFFFFFFFF),
                borderRadius: BorderRadius.all(Radius.circular(10)),
                boxShadow: [
                  BoxShadow(
                    color: Color(0x40000000),
                    blurRadius: 4,
                    offset: Offset(0, 0),
                  ),
                ],
              ),
              child: GestureDetector(
                onTap: () {

                  Navigator.pushReplacement(
                    context,
                    MaterialPageRoute(builder: (context) => ChangeName()),
                  );
                },

                child: Row(
                  mainAxisAlignment: MainAxisAlignment.start,
                  children: [
                    SvgPicture.asset(
                      'assets/person.svg',
                      semanticsLabel: 'Name',
                      width: 28,
                      height: 28,
                    ),

                    SizedBox(width: 20),

                    Text(
                      'Изменить имя',
                      style: TextStyle(
                        color: Color(0xFF555454),
                        fontSize: 18,
                      ),
                    ),

                  ],
                ),
              ),
            ),

            SizedBox(height: 25),
            Container(
              padding: EdgeInsets.symmetric(horizontal: 20),
              width: 318,
              height: 38,
              decoration: BoxDecoration(
                color: Color(0xFFFFFFFF),
                borderRadius: BorderRadius.all(Radius.circular(10)),
                boxShadow: [
                  BoxShadow(
                    color: Color(0x40000000),
                    blurRadius: 4,
                    offset: Offset(0, 0),
                  ),
                ],
              ),
              child: GestureDetector(
                onTap: () {
                  Navigator.push(
                    context,
                    MaterialPageRoute(
                        builder: (context) => ForgotPasswordEmailScreen()),
                  );
                },
                child: Row(
                  mainAxisAlignment: MainAxisAlignment.start,
                  children: [
                    SvgPicture.asset(
                      'assets/paroll.svg',
                      semanticsLabel: 'Password',
                      width: 28,
                      height: 28,
                    ),
                    SizedBox(width: 20),
                    Text(
                      'Изменить пароль',
                      style: TextStyle(
                        color: Color(0xFF555454),
                        fontSize: 18,
                      ),
                    ),
                  ],
                ),
              ),
            ),
            // Logout Button
            SizedBox(height: 60),

            MaterialButton(
              onPressed: () {
                GlobalToken().logout();
                Navigator.pushReplacement(
                  context,
                  MaterialPageRoute(builder: (context) => LoginScreen()),
                );
              },
              child: Container(
                width: 250,
                height: 40,
                decoration: BoxDecoration(
                  color: Color(0xFFB0183D),
                  boxShadow: [
                    BoxShadow(
                      color: Color(0x40000000),
                      blurRadius: 4,
                      offset: Offset(0, 0),
                    ),
                  ],
                  borderRadius: BorderRadius.circular(18),
                ),
                child: Center(
                  child: Text(
                    'Выйти из аккаунта',
                    style: TextStyle(
                      color: Colors.white,
                      fontSize: 20,
                    ),
                  ),
                ),
              ),
            ),
          ],
        ),
      ),
    );
  }


  Future<void> _openChangeDataDialog(BuildContext context, String title,
      {bool isPasswordDialog = false}) async {
    return showDialog(
      context: context,
      builder: (BuildContext context) {
        return AlertDialog(
          backgroundColor: Color(0xFFFFFFFF),
          title: Text(
            title,
            style: TextStyle(
              color: Color(0xFF0084AD),
            ),
          ),
          content: TextFormField(
            obscureText: isPasswordDialog,
            decoration: InputDecoration(
              hintText: isPasswordDialog ? 'Enter new password' : 'Enter data',
            ),
          ),
          actions: <Widget>[
            TextButton(
              child: Text('Save'),
              onPressed: () {
                if (isPasswordDialog) {
                  _openChangeDataDialog(context, 'Repeat old password',
                      isPasswordDialog: true);
                }
                Navigator.of(context).pop();
              },
            ),
            TextButton(
              child: Text('Cancel'),
              onPressed: () {
                Navigator.of(context).pop();
              },
            ),
          ],
        );
      },
    );
  }
}
