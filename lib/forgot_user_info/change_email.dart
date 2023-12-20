import 'package:flutter/material.dart';
import 'package:flutter/rendering.dart';
import 'package:http/http.dart' as http;
import 'dart:convert';
import 'package:flutter_svg/flutter_svg.dart';

import '../bottom_nav_bar.dart';
import '../main.dart';
import 'forgot_password.dart';

Future<String> sendEmail(String token, String newEmail) async {
  final url = Uri.parse('http://morderboy.ru/api/changeemail');
  final Map<String, String> requestBody = {'email': newEmail};
  final response = await http.patch(
    url,
    headers: {
      'Content-Type': 'application/json',
      'Authorization': 'Bearer $token',
    },
    body: jsonEncode({
      'email': newEmail
    }),
  );

  if (response.statusCode == 200) {
    print('Response body: ${response.body}');
    return response.body;
  } else {
    print('Failed to send reset code. Status code: ${response.statusCode}');
    print('Response body: ${response.body}');
    throw Exception('Failed to send reset code');
  }
}


class ChangeEmail extends StatelessWidget {

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Изменение почты'),
      ),
      body: Padding(
        padding: const EdgeInsets.all(20.0),
        child: Column(
          mainAxisAlignment: MainAxisAlignment.center,
          children: <Widget>[
            Expanded(
              child: ListView(
                children: <Widget>[
                  SizedBox(height: 140),


                  Center(
                    child: Container(
                      height: 60,
                      width: 380,
                      child: TextFormField(
                        style: TextStyle(fontSize: 20),
                        decoration: InputDecoration(
                          hintText: 'Введите почту',
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
                            borderSide:
                            BorderSide(color: Colors.blue, width: 2.0),
                            borderRadius: BorderRadius.circular(8.0),
                          ),
                          enabledBorder: OutlineInputBorder(
                            borderSide:
                            BorderSide(color: Colors.black, width: 1.0),
                            borderRadius: BorderRadius.circular(8.0),
                          ),
                        ),
                        onChanged: (value) {
                          GlobalData().email = value;
                        },
                      ),
                    ),
                  ),


                  SizedBox(height: 70),


                  ElevatedButton(
                    onPressed: () {
                      String token = GlobalToken().token;
                      String newEmail = GlobalData().email;

                      sendEmail(token, newEmail)
                          .then((response) {})
                          .catchError((error) {
                        print(error);
                      });

                      Navigator.push(
                        context,
                        MaterialPageRoute(
                            builder: (context) => BottomNavBar()),
                      );

                    },
                    style: ButtonStyle(
                      padding: MaterialStateProperty.all(EdgeInsets.zero),
                      minimumSize:
                      MaterialStateProperty.all(Size(342.16553, 50.31846)),
                      backgroundColor:
                      MaterialStateProperty.all(Color(0xFF0084AD)),
                      shape: MaterialStateProperty.all(RoundedRectangleBorder(
                        borderRadius: BorderRadius.circular(29.68789),
                      )),
                    ),

                    child: Container(
                      width: 342.16553,
                      height: 50.31846,
                      alignment: Alignment.center,
                      child: Text(
                        'Изменить',
                        style: TextStyle(color: Colors.white, fontSize: 20),
                      ),
                    ),
                  ),
                ],
              ),
            ),
          ],
        ),
      ),
    );
  }
}