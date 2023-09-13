import React from 'react'
import { useEffect } from 'react';
import { useState } from 'react';
import { useNavigate } from 'react-router-dom';
// import { LocalStorage } from 'node-localstorage';
// var localStorage = new LocalStorage("./backand/scratch");
// const userIsInactive = useFakeInactiveUser();


export default function Signin() {
    const navigate = useNavigate();
    const [credentials, setCredentials] = useState({ email: "", password: "" })

    const isLoggedin = () => {

        if (localStorage.getItem('email') !== null) {
            navigate('/home');
        }

    }

    const handleSubmit = async (e) => {
        e.preventDefault();

        const response = await fetch('http://localhost:5000/api/auth/login', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },

            body: JSON.stringify({ email: credentials.email, password: credentials.password })
        });

        const json = await response.json();
        console.log(json);


        // console.log(localStorage.getItem('userType'));

        if (json.success) {

            localStorage.setItem('token', json.success);
            localStorage.setItem('userType', json.userType);
            localStorage.setItem('email', json.email);

            if (json.userType === 'Recruiter') {
                window.location.reload(true);
                navigate("/fetchjobs");
            }
            else if (json.userType === 'Applicant') {
                window.location.reload(true);
                window.location = "/home";
                // navigate("/home");
            }


        }
        else {
            alert("Invalid Credentials");
        }
    }

    const onChange = (e) => {
        setCredentials({ ...credentials, [e.target.name]: e.target.value })
    }

    useEffect(() => {
        isLoggedin();
    })

    return (
        <>
            {/* <section className="vh-100"> */}
            <div className="container-fluid h-custom my-5">
                <div className="row d-flex justify-content-center align-items-center h-100">
                    <div className="col-md-9 col-lg-6 col-xl-5">
                        <img src="https://mdbcdn.b-cdn.net/img/Photos/new-templates/bootstrap-login-form/draw2.webp"
                            className="img-fluid" alt="" />
                    </div>
                    <div className="col-md-8 col-lg-6 col-xl-4 offset-xl-1">
                        <form method='POST' onSubmit={handleSubmit}>
                            {/* <div className="d-flex flex-row align-items-center justify-content-center justify-content-lg-start">
                                    <p className="lead fw-normal mb-0 me-3">Sign in with</p>
                                    <button type="button" className="btn btn-primary btn-floating mx-1">
                                        <i className="fa fa-facebook-f"></i>
                                    </button>

                                    <button type="button" className="btn btn-primary btn-floating mx-1">
                                        <i className="fa fa-twitter"></i>
                                    </button>

                                    <button type="button" className="btn btn-primary btn-floating mx-1">
                                        <i className="fa fa-linkedin"></i>
                                    </button>
                                </div> */}

                            {/* <div className="divider d-flex align-items-center my-4">
                                    <p className="text-center fw-bold mx-3 mb-0">Or</p>
                                </div> */}


                            <div className="form-outline mb-4">
                                <input type="email" id="form3Example3" className="form-control form-control-lg"
                                    placeholder="Enter a valid email address" name='email' onChange={onChange} />
                                {/* <label className="form-label" htmlFor="form3Example3">Email address</label> */}
                            </div>


                            <div className="form-outline mb-3">
                                <input type="password" id="form3Example4" className="form-control form-control-lg"
                                    placeholder="Enter password" name='password' onChange={onChange} />
                                {/* <label className="form-label" htmlFor="form3Example4">Password</label> */}
                            </div>

                            <div className="d-flex justify-content-between align-items-center">

                                {/* <div className="form-check mb-0">
                                    <input className="form-check-input me-2" type="checkbox" value="" id="form2Example3" />
                                    <label className="form-check-label" htmlFor="form2Example3">
                                        Remember me
                                    </label>
                                </div> */}
                                {/* <a href='/' className="text-body">Forgot password?</a> */}
                            </div>

                            <div className="text-center text-lg-start mt-4 pt-2">
                                <button type="submit" className="btn btn-primary btn-lg"
                                    Style="padding-left: 2.5rem; padding-right: 2.5rem;">Login</button>
                                <p className="small fw-bold mt-2 pt-1 mb-0">Don't have an account? <a href="/signup"
                                    className="link-danger">Register</a></p>
                            </div>

                        </form>
                    </div>
                </div>
            </div>

            {/* </section> */}
        </>
    )
}
