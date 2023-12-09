import 'package:flutter/material.dart';

class WorldSkillsPage_2 extends StatelessWidget {
  final List<IconData> icons = [
    Icons.handyman,
    Icons.design_services,
    Icons.agriculture,
    Icons.maps_home_work,
    Icons.location_city,
    Icons.local_florist,
    Icons.coronavirus,
    Icons.brush,
    Icons.local_atm,
    Icons.square_foot,
    Icons.architecture,
    Icons.settings_input_component,
    Icons.developer_board,
    Icons.color_lens,
    Icons.cleaning_services,
    Icons.delivery_dining,
  ];

  final List<String> texts = [
    "Строительство и строительные технологии",
    "Технологии креативных индустрий",
    "Сельское хозяйство и аграрные технологии",
    "Технологии образования",
    "Технологии индустрий гостеприимства",
    "Технологии индустрий природопользования",
    "Технологии медицины",
    "Технологии индустрий красоты",
    "Торговля и финансы",
    "Образование",
    "Abilympics",
    "Производство и инженерные технологии",
    "Информационные и коммуникационные технологии",
    "Творчество и дизайн",
    "Сфера услуг",
    "Транспорт и логистика"
  ];

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Компетенции чемпионата'),
      ),
      body: SingleChildScrollView(
        padding: EdgeInsets.all(40),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: <Widget>[
            SizedBox(height: 10),
            ListView.builder(
              shrinkWrap: true,
              physics: NeverScrollableScrollPhysics(),
              itemCount: texts.length,
              itemBuilder: (BuildContext context, int index) {
                return Padding(
                  padding: EdgeInsets.only(bottom: 40),
                  child: Row(
                    children: <Widget>[
                      Icon(icons[index], size: 60, color: Color(0xFFB0183D)),
                      SizedBox(width: 20),
                      Flexible(
                        child: Text(
                          texts[index],
                          style: TextStyle(
                            fontSize: 20,
                          ),
                        ),
                      ),
                    ],
                  ),
                );
              },
            ),
          ],
        ),
      ),
    );
  }
}
