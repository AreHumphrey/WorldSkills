import 'package:flutter/material.dart';
import 'package:wordskills/central_page.dart';
import 'profile_page.dart';
import 'results_page.dart';
import 'competition_page.dart';

class BottomNavBar extends StatefulWidget {
  const BottomNavBar({Key? key}) : super(key: key);

  @override
  _BottomNavBarState createState() => _BottomNavBarState();
}

class _BottomNavBarState extends State<BottomNavBar> {
  int _selectedIndex = 0;

  static final List<Widget> _pages = <Widget>[
    CentralPage(),
    CompetitionPage(),
    ResultsPage(),
    ProfilePage(),
  ];

  void _onItemTapped(int index) {
    setState(() {
      _selectedIndex = index;
    });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Stack(
        children: <Widget>[
          Center(
            child: _pages.elementAt(_selectedIndex),
          ),

          Positioned(
            bottom: 10,
            left: 0,
            right: 0,
            child: Container(
              height: 75,
              decoration: BoxDecoration(
                color: Colors.white,
              ),
              child: Theme(
                data: Theme.of(context).copyWith(
                  splashColor: Colors.transparent,
                  highlightColor: Colors.transparent,
                  canvasColor: Colors.transparent,
                  textTheme: Theme.of(context).textTheme.copyWith(
                        caption: TextStyle(
                            color: Colors.transparent),
                      ),
                  iconTheme: IconThemeData(
                      size: 50,
                      color:
                          Color(0xFF0084AD)),
                ),
                child: BottomNavigationBar(
                  type: BottomNavigationBarType.fixed,
                  backgroundColor: Colors.white,
                  items: const <BottomNavigationBarItem>[
                    BottomNavigationBarItem(
                      icon:
                          Icon(Icons.home, size: 50, color: Color(0xFF0084AD)),
                      activeIcon:
                          Icon(Icons.home, size: 50, color: Color(0xFF003764)),
                      label: '',
                    ),
                    BottomNavigationBarItem(
                      icon: Icon(Icons.school,
                          size: 50, color: Color(0xFF0084AD)),
                      activeIcon: Icon(Icons.school,
                          size: 50, color: Color(0xFF003764)),
                      label: '',
                    ),
                    BottomNavigationBarItem(
                      icon: Icon(Icons.emoji_events,
                          size: 50, color: Color(0xFF0084AD)),
                      activeIcon: Icon(Icons.emoji_events,
                          size: 50, color: Color(0xFF003764)),
                      label: '',
                    ),
                    BottomNavigationBarItem(
                      icon: Icon(Icons.account_circle,
                          size: 50, color: Color(0xFF0084AD)),
                      activeIcon: Icon(Icons.account_circle,
                          size: 50, color: Color(0xFF003764)),
                      label: '',
                    ),
                  ],
                  currentIndex: _selectedIndex,
                  selectedItemColor: const Color(0xFF003764),
                  unselectedItemColor: const Color(0xFF0084AD),
                  onTap: _onItemTapped,
                  selectedLabelStyle: TextStyle(fontSize: 0),
                  unselectedLabelStyle: TextStyle(fontSize: 0),
                ),
              ),
            ),
          ),
        ],
      ),
    );
  }
}
