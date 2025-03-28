// eslint-disable-next-line no-unused-vars
import React from "react";
import Header from "../components/Header";
//import HeaderJ from "../layout/HeaderJ";
import Footer from "../components/Footer";
import { Outlet } from "react-router-dom";
import { CssBaseline } from "@mui/material";

const RootLayout = () => {
  return (
    <div>
      <CssBaseline />
      <Header />

      <div>
        <Outlet />
      </div>
      <Footer />
    </div>
  );
};

export default RootLayout;
