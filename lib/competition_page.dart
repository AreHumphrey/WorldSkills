
import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'dart:convert';

import 'main.dart';

class CompetitionPage extends StatefulWidget {
  @override
  _CompetitionPageState createState() => _CompetitionPageState();
}

class _CompetitionPageState extends State<CompetitionPage> {
  String token = GlobalToken().token;
  int championshipId = 0;
  String competenceId = '';

  @override
  void initState() {
    super.initState();
    fetchData();
  }

  void fetchData() async {
    String url = 'http://morderboy.ru/api/userchampionship';

    Map<String, String> headers = {
      'Authorization': 'Bearer $token',
    };

    try {
      http.Response response = await http.get(Uri.parse(url), headers: headers);

      if (response.statusCode == 200) {
        var data = json.decode(response.body);
        setState(() {
          championshipId = data['ChampionshipId'];
          competenceId = data['CompetenceId'];
        });
      } else if (response.statusCode == 400) {
        var errorData = json.decode(response.body);

        if (errorData['error'] == 'Bad Role') {

          print('Данное API рассчитано на обычных пользователей');

        }
      }
    } catch (error) {
      print('Error fetching data: $error');
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Container(
        child: Column(
          mainAxisAlignment: MainAxisAlignment.start,
          children: <Widget>[

            SizedBox(height: 90),

            Center(
              child: Positioned(
                top: 100,
                child: Text(
                  'Чемпионат',
                  style: TextStyle(
                    fontSize: 35,
                    fontWeight: FontWeight.w700,
                    color: Color(0xFF003764),
                  ),
                ),
              ),
            ),
            SizedBox(height: 30),

            Center(
              child: Image.asset(
                'assets/compe.png',
                width: 240,
                height: 240,
              ),
            ),

            SizedBox(height: 20),

            Text(
              '$championshipId',
              style: TextStyle(
                fontSize: 60,
                color: Color(0xFFB0183D),
                fontWeight: FontWeight.bold,
              ),
            ),

            SizedBox(height: 20),

            Text(
              'Моя компетенция',
              style: TextStyle(
                fontSize: 30,
                color: Color(0xFF003764),
                fontWeight: FontWeight.bold,
              ),
            ),

            SizedBox(height: 40),

            MaterialButton(
              onPressed: () {},
              child: Container(
                width: 300,
                height: 74,
                decoration: BoxDecoration(
                  color: Colors.white,
                  borderRadius: BorderRadius.circular(18),
                  border: Border.all(
                    color: Color(0xFFB0183D),
                    width: 2,
                  ),
                ),
                child: Center(
                  child: Text(
                    '$competenceId',
                    style: TextStyle(
                      color: Color(0xFFB0183D),
                      fontSize: 22,
                      fontWeight: FontWeight.bold,
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
}
