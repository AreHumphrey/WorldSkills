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
      body: Align(
      alignment: Alignment.topCenter,
        child: Stack(
          children: <Widget>[

              Column(
                mainAxisAlignment: MainAxisAlignment.start,
                children: <Widget>[

                    Container(
                      child: Image.asset(
                        'assets/m_info.png',
                        width: 430,
                        height: 430,
                      ),
                    ),

                  GestureDetector(
                    onTap: () {
                      Navigator.push(
                        context,
                        MaterialPageRoute(builder: (context) => WorldSkillsPage_1()),
                      );
                    },
                    child: Container(
                      width: 318,
                      height: 58,
                      decoration: BoxDecoration(
                        color: Color(0xFF0084AD),
                        borderRadius: BorderRadius.circular(10),
                      ),
                      child: Center(
                        child: Text(
                          'История WorldSkills',
                          style: TextStyle(
                            fontSize: 25,
                            fontWeight: FontWeight.w500,
                            color: Colors.white,
                          ),
                          textAlign: TextAlign.center,
                        ),
                      ),
                    ),
                  ),


                  SizedBox(height: 40),

                  GestureDetector(
                    onTap: () {
                      Navigator.push(
                        context,
                        MaterialPageRoute(builder: (context) => WorldSkillsPage_2()),
                      );
                    },
                    child: Container(
                      width: 318,
                      height: 58,
                      decoration: BoxDecoration(
                        color: Color(0xFF0084AD),
                        borderRadius: BorderRadius.circular(10),
                      ),
                      child: Center(
                        child: Text(
                          'Компетенции',
                          style: TextStyle(
                            fontSize: 25,
                            fontWeight: FontWeight.w500,
                            color: Colors.white,
                          ),
                          textAlign: TextAlign.center,
                        ),
                      ),
                    ),
                  ),


                  SizedBox(height: 40),


                  GestureDetector(
                    onTap: () {
                      Navigator.push(
                        context,
                        MaterialPageRoute(builder: (context) => WorldSkillsPage_3()),
                      );
                    },
                    child: Container(
                      width: 318,
                      height: 58,
                      decoration: BoxDecoration(
                        color: Color(0xFF0084AD),
                        borderRadius: BorderRadius.circular(10),
                      ),
                      child: Center(
                        child: Text(
                          'История проведения',
                          style: TextStyle(
                            fontSize: 25,
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
