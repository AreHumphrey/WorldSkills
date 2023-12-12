import 'package:flutter/material.dart';
import 'package:flutter/rendering.dart';
import 'package:wordskills/bottom_nav_bar.dart';
import 'package:http/http.dart' as http;
import 'dart:convert';
import 'package:flutter_svg/flutter_svg.dart';

class ForgotPasswordEmailScreen extends StatelessWidget {
  TextEditingController emailController = TextEditingController();

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Восстановление пароля'),
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
                              'assets/mail.svg',
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
                        onChanged: (value) {},
                      ),
                    ),
                  ),
                  SizedBox(height: 170),
                  ElevatedButton(
                    onPressed: () {
                      String email = emailController.text;
                      Navigator.push(
                        context,
                        MaterialPageRoute(
                            builder: (context) => VerificationCodeScreen()),
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
                        'Отправить код',
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

class VerificationCodeScreen extends StatelessWidget {
  final List<TextEditingController> controllers = List.generate(
    6,
    (index) => TextEditingController(),
  );

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      resizeToAvoidBottomInset: false,
      appBar: AppBar(
        title: Text('Подтверждение пароля'),
      ),
      body: Center(
        child: Column(
          mainAxisAlignment: MainAxisAlignment.center,
          children: <Widget>[

            Text(
              'Введите код',
              style: TextStyle(color: Colors.grey[800], fontSize: 25),
            ),

            SizedBox(height: 40),

            Row(
              mainAxisAlignment: MainAxisAlignment.spaceEvenly,
              children: List.generate(
                6,
                    (index) => Padding(
                  padding: EdgeInsets.symmetric(horizontal: 0),
                  child: Container(
                    width: 50.52174,
                    height: 55,
                    decoration: BoxDecoration(
                      color: Color(0x80B9B9BE),
                      borderRadius: BorderRadius.all(Radius.circular(5)),
                    ),
                    child: TextField(
                      controller: controllers[index],
                      textAlign: TextAlign.center,
                      keyboardType: TextInputType.number,
                      maxLength: 1,
                      decoration: InputDecoration(
                        counter: Offstage(),
                        enabledBorder: UnderlineInputBorder(
                          borderSide: BorderSide(color: Colors.transparent),
                        ),
                        focusedBorder: UnderlineInputBorder(
                          borderSide: BorderSide(color: Colors.transparent),
                        ),
                        border: InputBorder.none,

                      ),
                      onChanged: (value) {
                        if (index < 5 && value.isNotEmpty) {
                          FocusScope.of(context).nextFocus();
                        }
                      },
                    ),
                  ),
                ),
              ),
            ),

            SizedBox(height: 40),
            ElevatedButton(
              onPressed: () {
                Navigator.push(
                  context,
                  MaterialPageRoute(
                      builder: (context) => NewPasswordInputScreen()),
                );
              },
              style: ButtonStyle(
                padding: MaterialStateProperty.all(EdgeInsets.zero),
                minimumSize: MaterialStateProperty.all(Size(249, 50)),
                backgroundColor: MaterialStateProperty.all(Color(0xFF003764)),
                shape: MaterialStateProperty.all(RoundedRectangleBorder(
                  borderRadius: BorderRadius.circular(29.68789),
                )),
              ),
              child: Container(
                width: 249,
                height: 50,
                alignment: Alignment.center,
                child: Text(
                  'Обновить пароль',
                  style: TextStyle(
                    fontSize: 20,
                    color: Colors.white,
                  ),
                ),
              ),
            ),
            SizedBox(height: 270),
            Center(
              child: Column(
                mainAxisAlignment: MainAxisAlignment.center,
                children: <Widget>[
                  Text(
                    'Не пришел код?',
                    style: TextStyle(
                      fontSize: 20,
                    ),
                  ),
                  SizedBox(height: 20,),
                  ElevatedButton(
                    onPressed: () {

                    },

                    child: Text(
                      'Отправить код ещё раз',
                      style: TextStyle(color: Colors.white, fontSize: 20),
                    ),

                    style: ButtonStyle(
                      fixedSize: MaterialStateProperty.all(
                          Size(342.16553, 50.31846)),
                      backgroundColor: MaterialStateProperty.all(
                          Color(0xFF0084AD)),
                      shape: MaterialStateProperty.all(RoundedRectangleBorder(
                        borderRadius: BorderRadius.circular(
                            29.68789),

                      )),
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

class NewPasswordInputScreen extends StatelessWidget {
  @override
  Widget build(BuildContext context) {

    return Scaffold(
      resizeToAvoidBottomInset: false,
      appBar: AppBar(
        title: Text('Восстановление пароля'),
      ),
      body: Padding(
        padding: const EdgeInsets.all(20.0),
        child: Column(
          mainAxisAlignment: MainAxisAlignment.start,
          children: <Widget>[

            SizedBox(height: 40),

            Text(
              'Придумайте новый пароль',
              style: TextStyle(color: Colors.grey[800], fontSize: 25),
            ),

            SizedBox(height: 40),

            TextFormField(
              obscureText: true,
              style: TextStyle(fontSize: 20),
              decoration: InputDecoration(
                hintText: 'Введите новый пароль',
                hintStyle: TextStyle(fontSize: 20),
                contentPadding: EdgeInsets.symmetric(vertical: 15, horizontal: 20),
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
                // Обработка введенного нового пароля
              },
            ),

            SizedBox(height: 40),

            TextFormField(
              obscureText: true,
              style: TextStyle(fontSize: 20),
              decoration: InputDecoration(
                hintText: 'Подтвердите новый пароль',
                hintStyle: TextStyle(fontSize: 20),
                contentPadding: EdgeInsets.symmetric(vertical: 15, horizontal: 20),
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
                // Обработка подтверждения нового пароля
              },
            ),
            SizedBox(height: 340),
            ElevatedButton(
              onPressed: () {
                // Обработка нажатия кнопки для отправки нового пароля и его подтверждения
              },
              style: ButtonStyle(
                padding: MaterialStateProperty.all(EdgeInsets.zero),
                minimumSize: MaterialStateProperty.all(Size(342, 50)),

                backgroundColor: MaterialStateProperty.all(Color(0xFF0084AD)),
                shape: MaterialStateProperty.all(RoundedRectangleBorder(
                  borderRadius: BorderRadius.circular(30),
                )),
              ),
              child: Container(
                width: 342,
                height: 50,
                alignment: Alignment.center,
                child: Text(
                  'Поменять пароль',
                  style: TextStyle(color: Colors.white, fontSize: 20),
                ),
              ),
            ),
          ],
        ),
      ),
    );
  }
}


class DigitInputField extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    // Возвращает виджет с модификаторами каждой цифры кода
    return Container(
      width: 46.52174,
      height: 50,
      decoration: BoxDecoration(
        color: Color(0x80B9B9BE),
        borderRadius: BorderRadius.circular(5),
      ),
      // Добавьте виджет для ввода текста с нужными стилями
    );
  }
}
