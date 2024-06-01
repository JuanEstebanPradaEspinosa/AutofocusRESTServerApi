import React from "react";
import Header from "../components/Header";
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
