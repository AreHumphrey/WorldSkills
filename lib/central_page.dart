import 'package:flutter/material.dart';
import 'info_pages/world_skills_info.dart';
import 'info_pages/wold_skills_rus_info.dart';

class CentralPage extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: Color(0xFF003764),
      body: Center(
        child: Stack(
          alignment: Alignment.center,
          children: <Widget>[
            Column(
              mainAxisAlignment: MainAxisAlignment.start,
              children: <Widget>[
                SizedBox(height: 80),
                Image.asset(
                  'assets/icon_wh.png',
                  width: 350,
                  height: 350,
                ),
                SizedBox(height: 70),
                GestureDetector(
                  onTap: () {
                    Navigator.push(
                      context,
                      MaterialPageRoute(
                          builder: (context) => WorldSkills_Page()),
                    );
                  },
                  child: Container(
                    width: 318,
                    height: 60,
                    decoration:  BoxDecoration(
                      color: Color(0xFF02508F),
                      borderRadius: BorderRadius.circular(40),
                      border: Border.all(
                        color: Color(0xFF0960A6),
                        width: 2,
                      ),
                    ),
                    child: Center(
                      child: Text(
                        'О WorldSkills',
                        style: TextStyle(
                          fontSize: 25,
                          fontWeight: FontWeight.w500,
                          color: Color(0xFFFFFFFF),
                        ),
                        textAlign: TextAlign.center,
                      ),
                    ),
                  ),
                ),
                SizedBox(height: 70),
                GestureDetector(
                  onTap: () {
                    Navigator.push(
                      context,
                      MaterialPageRoute(
                          builder: (context) => WorldSkills_Page_Rus()),
                    );
                  },
                  child: Container(
                    width: 318,
                    height: 60,
                    decoration: BoxDecoration(
                      color: Color(0xFF02508F),
                      borderRadius: BorderRadius.circular(40),
                      border: Border.all(
                        color: Color(0xFF0960A6),
                        width: 2,
                      ),
                    ),
                    child: Center(
                      child: Text(
                        'О WorldSkills Russia',
                        style: TextStyle(
                          fontSize: 22,
                          fontWeight: FontWeight.w500,
                          color: Color(0xFFFFFFFF),
                        ),
                        textAlign: TextAlign.center,
                      ),
                    ),
                  ),
                ),
              ],
            ),
          ],
        ),
      ),
    );
  }
}
