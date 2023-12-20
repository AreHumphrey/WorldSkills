import Logoimg from './../../img/sq.white.png'
import './header.css'

function Header () {
    return <header className="header"> 
        <div className="container">
            <div className="header_row">
                <div className="header_logo">
                    <img src={Logoimg} alt='Logo'/>
                </div>
                <nav className='header_nav'>
                    <ul>
                        <li><a href="#promo-content">О WorldSkills</a></li>
                        <li><a href="#promo-content2">O WorldSkills Russia</a></li>
                        <li><a href='#promo-content3'>О Краснодарском крае</a></li>
                        <li><a href='/login'>Войти</a></li>

                    </ul>
                </nav>
            </div>
        </div>   
    </header>
    
}

export default Header