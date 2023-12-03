import img1 from './../../img/image 1.png'
import img2 from './../../img/image 2.png'
import './promo2.css';

const Promo2 = () => {
    return (<section className='promo2'>
        <div id='promo-content2'>
            <div className='promo2-img'>
                <img src={img1} alt='image1'/>
                <img src={img2} alt='image2'/>
            </div>
            <div className='promo2-text'>
                <h1>О WorldSkills Russia</h1>
                <p>WorldSkills Russia, также известная как "Молодые Профессионалы (Ворлдскиллс Россия)", является автономной некоммерческой организацией, функциональным преемником Союза "Молодые профессионалы (Ворлдскиллс Россия)". Наша организация занимается развитием профессионального мастерства и содействием внедрению новых стандартов рабочих профессий.</p>
            </div>
        </div>
    </section>
    );
}
 
export default Promo2;