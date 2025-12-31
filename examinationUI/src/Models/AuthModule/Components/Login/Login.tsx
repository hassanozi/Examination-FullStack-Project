import React from "react";
import logo from "../../../../assets/images/Logo-white.svg";
import auth from "../../../../assets/images/Auth_Image.svg";
import signin from "../../../../assets/images/signin-ico.svg";
import signup from "../../../../assets/images/signup-ico.svg";
import "./Login.module.css"; 
import { Link, useNavigate } from 'react-router-dom'

export default function Login() {
  return (
    <section
      className="bg-dark"
      style={{ backgroundColor: "#121212", minHeight: "100vh", width: "100vw" }}
    >
      <div className="container-fluid p-4 px-5">
        <div className="row gx-0">
          {/* Left side */}
          <div className="col-12 col-md-7 col-lg-6 full_height px-5">
            <div>
              <img src={logo} className="w-25" alt="" />
            </div>
            <h2 className="text-mainColor_lightGreen my-4 text-white">
              Continue your learning journey with QuizWiz!
            </h2>

            <div className="my-1 mb-3 py-4 d-flex gap-3">
              <button
                className="Sign d-flex align-items-center gap-2"
                style={{
                  backgroundColor: "#1b1b1b",
                  color: "#fff",
                  padding: "8px 20px",
                  borderRadius: "10px",
                  width: "120px"
                }}
              >
                <img src={signin} alt="Sign In" style={{ width: "30px", height: "30px" }} />
                Sign In
              </button>
                <Link to="/register" style={{ textDecoration: "none" }}>
                  <button
                    className="Sign d-flex align-items-center gap-2"
                    style={{
                      backgroundColor: "#1b1b1b",
                      color: "#fff",
                      padding: "8px 20px",
                      borderRadius: "10px",
                      width: "120px"
                    }}
                  >
                    <img src={signup} alt="Sign Up" style={{ width: "30px", height: "30px" }} />
                    Sign Up
                  </button>
              </Link>
            </div>

            <form className="w-100 mt-5 pt-2">
              {/* Email */}
              <div className="form-item w-100">
                <label className="text-white">Your Email Address</label>
                <div className="input-group mb-3 custom-input">
                  <span className="input-group-text px-3 py-3 bg-transparent text-white rounded rounded-start-3 rounded-end-0 border border-4 border-end-0">
                    <i className="fa-solid fa-envelope"></i>
                  </span>
                  <div className="y-line my-auto"></div>
                  <input
                    type="email"
                    className="form-control rounded-end py-1 bg-transparent text-white ps-3 border border-4"
                    placeholder=" Type your Email"
                  />
                </div>
              </div>

              {/* Password */}
              <div className="form-item w-100">
                <label className="text-white">Your Password</label>
                <div className="input-group mb-3 custom-input">
                  <span className="input-group-text px-3 py-3 bg-transparent text-white rounded rounded-start-3 rounded-end-0 border border-4 border-end-0">
                    <i className="fa-solid fa-key"></i>
                  </span>
                  <div className="y-line my-auto"></div>
                  <input
                    type="password"
                    className="form-control rounded-end py-1 bg-transparent text-white ps-3 border border-4"
                    placeholder="Type your password"
                  />
                </div>
              </div>


              <div className="col-md-12 d-flex justify-content-between align-items-center mt-3">
                <button className="submit" type="submit">
                  <span className="text me-1">Sign in</span>
                  <span>
                    <i className="fa-solid fa-circle-check"></i>
                  </span>
                  <div className="bg-true">
                    <i className="fa-solid fa-circle-check"></i>
                  </div>
                </button>

                <a className="text-mainColor_lightGreen fw-medium text-white">
                  Forget Password?
                </a>
              </div>
            </form>
          </div>

          {/* Right side image with light yellow background */}
          <div
            className="col-md-5 col-lg-6 border rounded-5 d-none d-md-flex justify-content-center align-items-center"
            style={{ backgroundColor: "#FFF9C4" }} // Light yellow
          >
            <div className="w-75" id="image-container">
              <img src={auth} className="w-100" alt="" />
            </div>
          </div>
        </div>
      </div>
    </section>
  );
}
