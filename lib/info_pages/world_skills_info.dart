import 'package:flutter/material.dart';
import 'package:wordskills/info_pages/world_skills_info_1.dart';
import 'package:wordskills/info_pages/world_skills_info_2.dart';
import 'package:wordskills/info_pages/world_skills_info_3.dart';

class WorldSkills_Page extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(

      ),
      body: Center(
        child: Stack(
          alignment: Alignment.center,
          children: <Widget>[
            Positioned(
              top: 30,
              child: Text(
                'О WorldSkills',
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
                      MaterialPageRoute(builder: (context) => WorldSkillsPage_1()),
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
                        'История WorldSkills',
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
                      MaterialPageRoute(builder: (context) => WorldSkillsPage_2()),
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
                        'Компетенции чемпионата',
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
                      MaterialPageRoute(builder: (context) => WorldSkillsPage_3()),
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
                        'История проведения',
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

              ],
            ),
          ],
        ),
      ),
    );
  }
}
