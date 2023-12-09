import 'package:flutter/material.dart';
import 'info_pages/world_skills_info.dart';
import 'info_pages/wold_skills_rus_info.dart';

class CentralPage extends StatelessWidget {
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
                'WorldSkills',
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
                GestureDetector(
                  onTap: () {
                    Navigator.push(
                      context,
                      MaterialPageRoute(builder: (context) => WorldSkills_Page()),
                    );
                  },
                  child: Container(
                    width: 232,
                    height: 241,
                    padding: EdgeInsets.all(8),
                    decoration: BoxDecoration(
                      color: Colors.white,
                      borderRadius: BorderRadius.circular(8),
                      boxShadow: [
                        BoxShadow(
                          color: Color(0x40000000),
                          offset: Offset(0, 4),
                          blurRadius: 4,
                        ),
                      ],
                      border: Border.all(width: 1, color: Color(0xFF003764)),
                    ),
                    child: Column(
                      mainAxisAlignment: MainAxisAlignment.spaceBetween,
                      children: <Widget>[
                        SizedBox(height: 20),
                        Expanded(
                          child: ClipRRect(
                            child: Image.asset(
                              'assets/worldskills_info.jpg',
                              fit: BoxFit.cover,
                              height: 20,
                              width: 170,
                            ),
                          ),
                        ),
                        SizedBox(height: 20),
                        Container(
                          width: 208,
                          height: 65,
                          decoration: BoxDecoration(
                            color: Color(0xFFEAE9E9),
                            borderRadius: BorderRadius.circular(8),
                          ),
                          child: Center(
                              child: Text(
                            'О WorldSkills',
                            style: TextStyle(
                              fontSize: 22,
                              fontWeight: FontWeight.w500,
                              color: Color(0xFF003764),
                            ),
                          )),
                        ),
                      ],
                    ),
                  ),
                ),
                SizedBox(height: 40),
                GestureDetector(
                  onTap: () {
                    Navigator.push(
                      context,
                      MaterialPageRoute(builder: (context) => WorldSkills_Page_Rus()),
                    );
                  },
                  child: Container(
                    width: 232,
                    height: 241,
                    padding: EdgeInsets.all(8),
                    decoration: BoxDecoration(
                      color: Colors.white,
                      borderRadius: BorderRadius.circular(8),
                      boxShadow: [
                        BoxShadow(
                          color: Color(0x40000000),
                          offset: Offset(0, 4),
                          blurRadius: 4,
                        ),
                      ],
                      border: Border.all(width: 1, color: Color(0xFF003764)),
                    ),
                    child: Column(
                      mainAxisAlignment: MainAxisAlignment.spaceBetween,
                      children: <Widget>[
                        SizedBox(height: 20),
                        Expanded(
                          child: ClipRRect(
                            child: Image.asset(
                              'assets/worldskills_rus_info.jpg',
                              fit: BoxFit.cover,
                              height: 20,
                              width: 170,
                            ),
                          ),
                        ),
                        SizedBox(height: 20),
                        Container(
                            width: 208,
                            height: 65,
                            decoration: BoxDecoration(
                              color: Color(0xFFEAE9E9),
                              borderRadius: BorderRadius.circular(8),
                            ),
                            child: Center(
                              child: Text(
                                'О WorldSkills Russia',
                                style: TextStyle(
                                  fontSize: 20,
                                  fontWeight: FontWeight.w500,
                                  color: Color(0xFF003764),
                                ),
                                textAlign: TextAlign.center,
                              ),
                            )),
                      ],
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
