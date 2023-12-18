import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'package:wordskills/widgets/custom_competency_button.dart';
import 'dart:convert';

import 'competency/competency_experts.dart';
import 'competency/competency_map.dart';
import 'competency/competency_user.dart';
import 'main.dart';

class GlobalChampion {
  static final GlobalChampion _instance = GlobalChampion._internal();

  factory GlobalChampion() => _instance;

  GlobalChampion._internal();

  String competenceId = '';
  int championshipId = 0;
}


class CompetitionPage extends StatefulWidget {
  @override
  _CompetitionPageState createState() => _CompetitionPageState();
}

class _CompetitionPageState extends State<CompetitionPage> {
  String token = GlobalToken().token;
  GlobalChampion globalChampion = GlobalChampion();

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
          GlobalChampion().championshipId = data['ChampionshipId'];
          GlobalChampion().competenceId = data['CompetenceId'];
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
              GlobalChampion().championshipId != 0
                  ? '${globalChampion.championshipId}'
                  : 'Вы не участвуете в чемпионате',
              style: TextStyle(
                fontSize: GlobalChampion().championshipId != 0 ? 60 : 20,
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

            Visibility(
              visible: GlobalChampion().competenceId != '',

              child: MaterialButton(
                onPressed: () {
                  Navigator.push(
                    context,
                    MaterialPageRoute(
                      builder: (context) => CompetencyCriteriaPage(),
                    ),
                  );
                },
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
                      GlobalChampion().competenceId != ' '
                          ? '${GlobalChampion().competenceId}'
                          : 'Компетенция не выбрана',
                      style: TextStyle(
                        color: Color(0xFFB0183D),
                        fontSize: 30,
                        fontWeight: FontWeight.bold,
                      ),
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

class CompetencyCriteriaPage extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(),
      body: Padding(
        padding: const EdgeInsets.all(16.0),
        child: Column(
          mainAxisAlignment: MainAxisAlignment.start,
          children: <Widget>[
            Center(
              child: Positioned(
                top: 30,
                child: Text(
                  'Критерии',
                  style: TextStyle(
                    fontSize: 35,
                    fontWeight: FontWeight.w700,
                    color: Color(0xFF003764),
                  ),
                ),
              ),
            ),
            SizedBox(height: 40),
            Row(
              mainAxisAlignment: MainAxisAlignment.spaceEvenly,
              children: <Widget>[
                CompetencyButton(
                  image: 'assets/user.png',
                  text: 'Участники',
                  onPressed: () {
                    Navigator.push(
                      context,
                      MaterialPageRoute(
                          builder: (context) => CompetitionUser()),
                    );
                  },
                ),
                CompetencyButton(
                  image: 'assets/ex.png',
                  text: 'Эксперты',
                  onPressed: () {
                    Navigator.push(
                      context,
                      MaterialPageRoute(
                          builder: (context) => CompetitionExperts()),
                    );
                  },
                ),
              ],
            ),
            SizedBox(height: 40),
            Row(
              mainAxisAlignment: MainAxisAlignment.spaceEvenly,
              children: <Widget>[
                CompetencyButton(
                  image: 'assets/map.png',
                  text: 'План\n застройки',
                  onPressed: () {
                    Navigator.push(
                      context,
                      MaterialPageRoute(
                          builder: (context) => CompetitionMap()),
                    );
                  },
                ),
                CompetencyButton(
                  image: 'assets/mark.png',
                  text: 'Инфроструктура',
                  onPressed: () {
                    Navigator.push(
                      context,
                      MaterialPageRoute(
                          builder: (context) => CompetitionPage()),
                    );
                  },
                ),
              ],
            ),
            SizedBox(height: 40),
            Center(
              child: CompetencyButton(
                image: 'assets/clock.png',
                text: 'SMP',
                onPressed: () {
                  Navigator.push(
                    context,
                    MaterialPageRoute(builder: (context) => CompetitionPage()),
                  );
                },
              ),
            )
          ],
        ),
      ),
    );
  }
}


