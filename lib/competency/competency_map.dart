import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'package:wordskills/main.dart';
import 'package:url_launcher/url_launcher.dart';

import '../competition_page.dart';

class CompetitionMap extends StatefulWidget {
  @override
  _CompetitionMapState createState() => _CompetitionMapState();
}

class _CompetitionMapState extends State<CompetitionMap> {
  late String mapUrl = '';
  String token = GlobalToken().token;
  GlobalChampion globalChampion = GlobalChampion();

  Future<void> fetchMapUrl() async {
    final url = Uri.parse(
        'http://morderboy.ru/api/championships/link/${globalChampion.championshipId}');
    final response = await http.get(
      url,
      headers: {'Authorization': 'Bearer $token'},
    );

    if (response.statusCode == 200) {
      String responseData = response.body;

      await launch(responseData);
    } else if (response.statusCode == 404) {
      print('Чемпионат не найден в базе данных');
    } else if (response.statusCode == 400) {
      print('У данного чемпионата отсутствует адрес');
    } else {
      print('Произошла ошибка: ${response.reasonPhrase}');
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        iconTheme: IconThemeData(color: Colors.white),
        backgroundColor: Color(0xFF003764),
      ),
      backgroundColor: Color(0xFF003764),
      body: Center(
        child: Column(
          children: <Widget>[
            Text(
              'План застройки',
              style: TextStyle(
                fontSize: 35,
                fontWeight: FontWeight.w700,
                color: Color(0xFFFFFFFF),
              ),
            ),

            SizedBox(height: 40),
            Expanded(
              child: Container(
                child: Image.asset(
                  'assets/map_img.png',
                  width: 430,
                  height: 430,
                ),
              ),
            ),
            SizedBox(height: 20),
            IconButton(
              icon: Image.asset(
                'assets/map_icon.png',
                width: 240,
                height: 240,
              ),
              onPressed: () {
                fetchMapUrl();
              },
            ),
            SizedBox(height: 20),
          ],
        ),
      ),
    );
  }
}

