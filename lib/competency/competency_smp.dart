import 'dart:io';

import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'package:wordskills/main.dart';
import 'package:open_file/open_file.dart';
import 'package:path_provider/path_provider.dart';

import '../competition_page.dart';

class CompetitionSmp extends StatefulWidget {
  @override
  _CompetitionSmpState createState() => _CompetitionSmpState();
}

class _CompetitionSmpState extends State<CompetitionSmp> {
  late String mapUrl = '';
  String token = GlobalToken().token;
  GlobalChampion globalChampion = GlobalChampion();

  void downloadExcelFiles() async {
    String url = 'http://morderboy.ru/api/files/SMP/Download/${GlobalChampion().championshipId}&${GlobalChampion().competenceId}';

    Map<String, String> headers = {
      'Authorization': 'Bearer ${GlobalToken().token}',
    };

    try {
      http.Response response = await http.get(Uri.parse(url), headers: headers);

      if (response.statusCode == 200) {

        final bytes = response.bodyBytes;
        final fileName = 'downloaded_file.pdf';
        String dir = (await getTemporaryDirectory()).path;
        String filePath = '$dir/$fileName';
        File file = File(filePath);
        await file.writeAsBytes(bytes);

        OpenFile.open(filePath);
      } else if (response.statusCode == 404) {
        print('Файл не найден');
      } else {
        print('Ошибка при скачивании файла: ${response.statusCode}');
      }
    } catch (error) {
      print('Ошибка при выполнении запроса: $error');
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
              'SMP',
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
                  'assets/smp_img.png',
                  width: 460,
                  height: 460,
                ),
              ),
            ),
            SizedBox(height: 20),
            IconButton(
              icon: Image.asset(
                'assets/download_icon.png',
                width: 240,
                height: 240,
              ),
              onPressed: () {
                downloadExcelFiles();
              },
            ),
            SizedBox(height: 20),
          ],
        ),
      ),
    );
  }
}

