import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'package:wordskills/competition_page.dart';
import 'dart:convert';

import 'package:wordskills/main.dart';

class CompetitionExperts extends StatefulWidget {
  @override
  _CompetitionUserState createState() => _CompetitionUserState();
}

class _CompetitionUserState extends State<CompetitionExperts> {
  String token = GlobalToken().token;
  GlobalChampion globalChampion = GlobalChampion();

  Future<List<Map<String, dynamic>>> fetchUsers() async {
    final response = await http.get(
      Uri.parse(
          'http://morderboy.ru/api/champcompetence/experts/${globalChampion.championshipId}&${globalChampion.competenceId}'),
      headers: {'Authorization': 'Bearer $token'},
    );

    if (response.statusCode == 200) {
      List<dynamic> data = json.decode(response.body);
      for (var user in data) {
        print(user);
      }
      return data.cast<Map<String, dynamic>>().toList();
    } else if (response.statusCode == 404) {
      throw Exception('Не найдено ни одного участника');
    } else {
      throw Exception('Ошибка при загрузке пользователей');
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text(
          'Эксперты',
          style: TextStyle(
            color: Color(0xFFFFFFFF),
          ),
        ),
        backgroundColor: Color(0xFF003764),
        iconTheme: IconThemeData(color: Colors.white),
      ),
      backgroundColor: Color(0xFF003764),
      body: Padding(
        padding: const EdgeInsets.all(18.0),
        child: FutureBuilder<List<Map<String, dynamic>>>(
          future: fetchUsers(),
          builder: (context, snapshot) {
            if (snapshot.connectionState == ConnectionState.waiting) {
              return Center(child: CircularProgressIndicator());
            } else if (snapshot.hasError) {
              return Center(child: Text('Ошибка: ${snapshot.error}'));
            } else if (snapshot.hasData && snapshot.data!.isNotEmpty) {
              return GridView.builder(
                padding: EdgeInsets.all(20),
                gridDelegate: SliverGridDelegateWithFixedCrossAxisCount(
                  crossAxisCount: 2,
                  crossAxisSpacing: 30,
                  mainAxisSpacing: 35,
                  childAspectRatio: 109 / 162,
                ),
                itemCount: snapshot.data!.length,
                itemBuilder: (context, index) {
                  Map<String, dynamic>? user = snapshot.data![index];
                  return Container(
                    decoration: BoxDecoration(
                      borderRadius: BorderRadius.circular(10),
                      border: Border.all(color: Color(0xFF003764), width: 1),
                      color: Colors.white,
                      boxShadow: [
                        BoxShadow(
                          color: Colors.grey.withOpacity(0.5),
                          spreadRadius: 2,
                          blurRadius: 4,
                          offset: Offset(0, 4),
                        ),
                      ],
                    ),
                    child: Column(
                      mainAxisAlignment: MainAxisAlignment.start,
                      children: <Widget>[
                        SizedBox(height: 20),
                        Center(
                          child: Image.asset(
                            'assets/avatar_users_ex.png',
                            width: 100,
                            height: 100,
                          ),
                        ),
                        SizedBox(height: 10),

                        Center(
                          child: Column(
                            mainAxisAlignment: MainAxisAlignment.center,
                            children: <Widget>[
                              Text(
                                '${user?['FirstName'] ?? 'Unknown'}\n',
                                style: TextStyle(
                                  fontWeight: FontWeight.bold,
                                  color: Color.fromRGBO(82, 82, 82, 1),
                                  fontSize: 16,
                                ),
                                textAlign: TextAlign.center,
                              ),
                              Text(
                                '${user?['LastName'] ?? 'Unknown'}',
                                style: TextStyle(
                                  fontWeight: FontWeight.bold,
                                  color: Color.fromRGBO(82, 82, 82, 1),
                                  fontSize: 16,
                                ),
                                textAlign: TextAlign.center,
                              ),
                            ],
                          ),
                        ),
                        SizedBox(height: 4),
                        Text(
                          '${user?['Regionname'] ?? 'Unknown'}',
                          style: TextStyle(
                            fontWeight: FontWeight.bold,
                            color: Color.fromRGBO(82, 82, 82, 1),
                            fontSize: 16,
                          ),
                        ),
                      ],
                    ),
                  );
                },
              );
            } else {
              return Center(child: Text('Не найдено ни одного участника'));
            }
          },
        ),
      ),
    );
  }
}
