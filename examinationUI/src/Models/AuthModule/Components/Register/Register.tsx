import React from "react";
import { Link } from "react-router-dom";
import logo from "../../../../assets/images/Logo-white.svg";
import auth from "../../../../assets/images/Auth_Image.svg";
import signin from "../../../../assets/images/signin-ico.svg";
import signup from "../../../../assets/images/signup-ico.svg";
import "./Register.module.css"; // reuse same styles

export default function Register() {
  return (
    <section
      className="bg-dark"
      style={{ backgroundColor: "#121212", minHeight: "100vh", width: "100vw" }}
    >
      <div className="container-fluid p-4 px-5">
        <div className="row gx-0">

          {/* Left Side */}
          <div className="col-12 col-md-7 col-lg-6 full_height px-5">
            <div>
              <img src={logo} className="w-25" alt="Logo" />
            </div>

            <h2 className="text-mainColor_lightGreen my-4 text-white">
              Continue your learning journey with QuizWiz!
            </h2>

            {/* Switch buttons */}
            <div className="my-1 mb-3 py-4 d-flex gap-3">

              <Link to="/login" style={{ textDecoration: "none" }}>
                <button className="Sign d-flex align-items-center gap-2">
                  <img src={signin} alt="Sign In" width={30} />
                  Sign In
                </button>
              </Link>

              <button className="Sign active d-flex align-items-center gap-2">
                <img src={signup} alt="Sign Up" width={30} />
                Sign Up
              </button>

            </div>

            {/* Register Form */}
            <form className="w-100 mt-4">

              <div className="d-flex gap-3">
                <div className="form-item w-100">
                  <label className="text-white">First Name</label>
                  <input
                    type="text"
                    className="form-control bg-transparent text-white border border-4"
                    placeholder="First name"
                  />
                </div>

                <div className="form-item w-100">
                  <label className="text-white">Last Name</label>
                  <input
                    type="text"
                    className="form-control bg-transparent text-white border border-4"
                    placeholder="Last name"
                  />
                </div>
              </div>

              <div className="form-item mt-3">
                <label className="text-white">Email Address</label>
                <input
                  type="email"
                  className="form-control bg-transparent text-white border border-4"
                  placeholder="Enter your email"
                />
              </div>

              <div className="form-item mt-3">
                <label className="text-white">Select Role</label>
                <select className="form-control bg-transparent text-white border border-4">
                  <option>Student</option>
                  <option>Instructor</option>
                </select>
              </div>

              <div className="form-item mt-3">
                <label className="text-white">Password</label>
                <input
                  type="password"
                  className="form-control bg-transparent text-white border border-4"
                  placeholder="Password"
                />
              </div>

              <div className="mt-4">
                <button className="submit" type="submit">
                  <span className="text me-1">Sign Up</span>
                  <span><i className="fa-solid fa-circle-check"></i></span>
                  <div className="bg-true">
                    <i className="fa-solid fa-circle-check"></i>
                  </div>
                </button>
              </div>

            </form>
          </div>

          {/* Right Side */}
          <div
            className="col-md-5 col-lg-6 border rounded-5 d-none d-md-flex justify-content-center align-items-center"
            style={{ backgroundColor: "#FFF9C4" }}
          >
            <div className="w-75" id="image-container">
              <img src={auth} className="w-100" alt="Auth" />
            </div>
          </div>

        </div>
      </div>
    </section>
  );
}
