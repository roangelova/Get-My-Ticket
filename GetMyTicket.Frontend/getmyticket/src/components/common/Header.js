import { useState } from 'react';
import logo from '../../assets/images/logo.png';
import '../../assets/style/css/style.css';
import Login from '../account/Login';

function Header() {

    const [LoginPopupVisibility, setLoginPopupVisibility] = useState(false);

    const handleLoginToggle = () => {
        setLoginPopupVisibility(true);
    };

    return (
        <div className='header__container'>
            <div className={`header ${LoginPopupVisibility ? 'blurred' : ''}`}>
                <div className='header__logoBox'>
                    <div>
                        <img src={logo} alt="Logo" className="header__logo">
                        </img>
                    </div>
                    <div className='header__heading'>
                        <h1>Tickify</h1>
                    </div>
                </div>
                <div className='header__navigation'>
                    <div className="header__navigation-browse">
                        <a href="http://localhost:3000/"  >
                            Trains
                        </ a>
                        <a href="http://localhost:3000/">
                            Buses
                        </ a >
                        <a href="http://localhost:3000/">
                            Flights
                        </a>
                    </div>
                    <div className='header__navigation-user'>
                        <a href='#'
                            className='header__navigation-login'
                            onClick={handleLoginToggle}
                        >
                            Login
                        </a>
                        <a href='/register'>
                            Sign up
                        </a>
                    </div>
                </div>
            </div>

            {
                LoginPopupVisibility ?
                    <div className='login'> <Login />
                    </div> :
                    null
            }

        </div >
    );
}

export default Header;