import React from "react";
import { useState } from "react";
import LoginDialog from "./LoginDialog";
import RegisterDialog from "./RegisterDialog";
import DrawerComp from "./DrawerComp";
import { AppBar, Toolbar, Typography, Tabs, Tab } from "@mui/material";
import { CarRental } from "@mui/icons-material";

const Header = () => {
  const [value, setValue] = useState();
  return (
    <AppBar position="relative">
      <Toolbar>
        <CarRental />
        <Typography variant="h6">Auto Focus</Typography>
        <Tabs
          textColor="inherit"
          value={value}
          onChange={(e, value) => setValue(value)}
        >
          <Tab label="Contacts" />
          <Tab label="My collection" />
          <Tab label="Services" />
          <Tab label="About us" />
        </Tabs>
        <div style={{ marginLeft: "auto", display: "flex", gap: "10px" }}>
          <LoginDialog />
          <RegisterDialog />
        </div>
      </Toolbar>
      <DrawerComp />
    </AppBar>
  );
};

export default Header;
