// eslint-disable-next-line no-unused-vars
import React from "react";
import { useLocation } from "react-router-dom";
import SignIn from "../components/SignIn";
import SignUp from "../components/SignUp";

const LoginPage = () => {
  const location = useLocation();
  const action = location.pathname.includes("login") ? "login" : "register";

  return (
    <div className="h-full bg-white">
      <div className="h-full">
        {action === "login" ? <SignIn /> : <SignUp />}
      </div>
    </div>
  );
};

export default LoginPage;
