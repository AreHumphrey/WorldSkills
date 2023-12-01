import 'package:flutter/material.dart';

class ProfilePage extends StatelessWidget {
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

    String userTitle = '';
    String userName = '';
    String gender = '';

    if (gender == 'male') {
      userTitle = 'Mr.';
    } else if (gender == 'female') {
      userTitle = 'Ms.';
    }

    return Scaffold(
      backgroundColor: Color(0xFFF3F3F4),
      body: Center(
        child: Column(
          mainAxisAlignment: MainAxisAlignment.start,
          children: [
            SizedBox(height: 70),
            CircleAvatar(
              radius: 120,
              backgroundColor: Colors.white,
            ),

            SizedBox(height: 10),


            Text(
              '$greeting\n$userTitle $userName!',
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
                  _openChangeDataDialog(context, 'Change Email');
                },
                child: Row(
                  mainAxisAlignment: MainAxisAlignment.start,
                  children: [
                    Icon(Icons.email, size: 28, color: Color(0xFF0084AD)),
                    SizedBox(width: 8),
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

            SizedBox(height: 20),

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
                  _openChangeDataDialog(context, 'Change Name');
                },
                child: Row(
                  mainAxisAlignment: MainAxisAlignment.start,
                  children: [
                    Icon(Icons.person, size: 28, color: Color(0xFF0084AD)),
                    SizedBox(width: 8),
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

            SizedBox(height: 20),
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
                  _openChangeDataDialog(context, 'Change Password');
                },
                child: Row(
                  mainAxisAlignment: MainAxisAlignment.start,
                  children: [
                    Icon(Icons.lock, size: 28, color: Color(0xFF0084AD)),
                    SizedBox(width: 8),
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
            SizedBox(height: 80),

            MaterialButton(
              onPressed: () {
                Navigator.pushReplacementNamed(context, '/login');
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
                  borderRadius: BorderRadius.circular(10),
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
