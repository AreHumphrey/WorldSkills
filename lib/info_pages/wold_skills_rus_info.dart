import 'package:flutter/material.dart';
import 'package:wordskills/info_pages/wold_skills_rus_info_1.dart';
import 'package:wordskills/info_pages/wold_skills_rus_info_2.dart';

class WorldSkills_Page_Rus extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Center(
        child: Stack(
          alignment: Alignment.center,
          children: <Widget>[
            Positioned(
              top: 100,
              child: Text(
                'WorldSkills Russia',
                style: TextStyle(
                  fontSize: 35,
                  fontWeight: FontWeight.w700,
                  color: Color(0xFF003764),
                ),
              ),
            ),
            Column(
              mainAxisAlignment: MainAxisAlignment.center,
              children: <Widget>[

                SizedBox(height: 60),

                GestureDetector(
                  onTap: () {
                    Navigator.push(
                      context,
                      MaterialPageRoute(builder: (context) => WorldSkillsPageRus_1()),
                    );
                  },
                  child: Container(
                    width: 318,
                    height: 112,
                    decoration: BoxDecoration(
                      color: Color(0xFF0084AD),
                      borderRadius: BorderRadius.circular(10),
                    ),
                    child: Center(
                      child: Text(
                        'О WorldSkills Russia',
                        style: TextStyle(
                          fontSize: 20,
                          fontWeight: FontWeight.w500,
                          color: Colors.white,
                        ),
                        textAlign: TextAlign.center,
                      ),
                    ),
                  ),
                ),


                SizedBox(height: 80),


                GestureDetector(
                  onTap: () {
                    Navigator.push(
                      context,
                      MaterialPageRoute(builder: (context) => WorldSkillsPageRus_2()),
                    );
                  },
                  child: Container(
                    width: 318,
                    height: 112,
                    decoration: BoxDecoration(
                      color: Color(0xFF0084AD),
                      borderRadius: BorderRadius.circular(10),
                    ),
                    child: Center(
                      child: Text(
                        'Цели и задачи',
                        style: TextStyle(
                          fontSize: 20,
                          fontWeight: FontWeight.w500,
                          color: Colors.white,
                        ),
                        textAlign: TextAlign.center,
                      ),
                    ),
                  ),
                ),


                SizedBox(height: 80),


              ],
            ),
          ],
        ),
      ),
    );
  }
}
