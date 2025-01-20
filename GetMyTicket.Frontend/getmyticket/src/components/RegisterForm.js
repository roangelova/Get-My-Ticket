import { Account } from "../services/accountService";

import { ToastContainer, toast } from 'react-toastify';

function RegisterForm() {

    let initialUserData = {
        firstName: '',
        lastName: '',
        email: '',
        password: '',
        dob: '',
        newsletterSubscribtion: true,
        address: '',
    };

    const registerUser = async (formData) => {
        let firstName = formData.get('firstName');
        let lastName = formData.get('lastName');
        let email = formData.get('email');
        let password = formData.get('password');
        let confirmPassword = formData.get('confirmPassword');
        let newsletterSubscribtion = formData.get('newsletterCheckbox');
        let address = formData.get('address');

        //perfom validation
        //TODO -> extends validation to check if email is indeed email, name only characters etc; 

        if (lastName == '' || firstName == '' || email == '' || address == '') {
            toast.error("All fields are required for registration! Please, try again.");
            return;
        }

        if (password !== confirmPassword) {
            toast.error("Password and confirm password do not match!")
            return;
        }

        let checkboxValue = newsletterSubscribtion === 'on' ? true : false;

        initialUserData.firstName = firstName;
        initialUserData.lastName = lastName;
        initialUserData.email = email;
        initialUserData.address = address;
        initialUserData.newsletterSubscribtion = checkboxValue;
        initialUserData.password = password;
        initialUserData.dob = "01.01.1997";

        Account.register(initialUserData).then(res => {
            if (res.succeeded) {
                toast.success("Registration successful. You can now log in and plan a trip!")
            }
        });
    }

    return (

        <div className="register">
            <ToastContainer />
            <form action={registerUser} className="register__container register__form">

                <div className="register__row">
                    <div>
                        <label htmlFor="firstName">First name</label>
                        <input
                            name="firstName"
                            type="text"
                            placeholder="First name"
                            autoComplete="on"
                            autoCapitalize="on"
                        ></input>
                    </div>

                    <div>
                        <label htmlFor="lastName" >Last name</label>
                        <input
                            name="lastName"
                            type="text"
                            placeholder="Last Name"
                            autoComplete="on"
                            autoCapitalize="on"
                        ></input>
                    </div>
                </div>

                <div className="register__row">
                    <div>
                        <label htmlFor="email">Email</label>
                        <input
                            name="email"
                            type="email"
                            placeholder="email@gmail.com"
                            autoComplete="on"
                        ></input>
                    </div>

                    <div>
                        <label htmlFor="password" >Password</label>
                        <input
                            name="password"
                            type="password"
                        ></input>
                    </div>

                    <div>
                        <label htmlFor="confirmPassword" >Confirm password</label>
                        <input
                            name="confirmPassword"
                            type="password"
                        ></input>
                    </div>
                </div>

                <div className="register__row-address">
                    <label
                        htmlFor="address">Address</label>
                    <input
                        className="register__row-address"
                        name="address"
                        type="address"></input>
                </div>

                <div className="register__row-checkbox">
                    <label
                        htmlFor="newsletterCheckbox">Send me special offers & other updates by email.</label>
                    <input
                        name="newsletterCheckbox"
                        type="checkbox"
                        defaultChecked="true"></input>
                </div>

                <div className="register__btn">
                    <button
                    >
                        Register
                    </button>
                </div>
            </form>
        </div>

    )
}

export default RegisterForm;