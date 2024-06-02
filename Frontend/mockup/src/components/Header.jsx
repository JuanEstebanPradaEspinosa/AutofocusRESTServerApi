import React from "react";
import { Link } from "react-router-dom";
import { useState } from "react";
import LoginDialog from "./LoginDialog";
import RegisterDialog from "./RegisterDialog";
import DrawerComp from "./DrawerComp";
import {
  AppBar,
  Toolbar,
  Typography,
  Tabs,
  Tab,
  useMediaQuery,
  useTheme,
  IconButton,
} from "@mui/material";
import { CarRental } from "@mui/icons-material";

const PAGES = [
  "Contacts",
  "My Collection",
  "Watchlist",
  "About Us",
  "Projects",
];

const Header = () => {
  const [value, setValue] = useState();

  const theme = useTheme();
  console.log(theme);
  const isMatch = useMediaQuery(theme.breakpoints.down("md"));
  console.log(isMatch);
  return (
    <AppBar position="relative" style={{ width: "auto" }}>
      <Toolbar>
        <IconButton component={Link} to="/" color="inherit">
          <CarRental />
        </IconButton>
        {isMatch ? (
          <>
            <Typography variant="h5">Auto Focus</Typography>
            <DrawerComp />
          </>
        ) : (
          <>
            <Tabs
              textColor="inherit"
              value={value}
              onChange={(e, value) => setValue(value)}
            >
              {PAGES.map((page, index) => (
                <Tab
                  key={index}
                  label={page}
                  component={Link}
                  to={`/${page.toLowerCase().replace(/ /g, "-")}`}
                />
              ))}
            </Tabs>
            <div style={{ marginLeft: "auto", display: "flex", gap: "10px" }}>
              <LoginDialog />
              <RegisterDialog />
            </div>
          </>
        )}
      </Toolbar>
    </AppBar>
  );
};

export default Header;
