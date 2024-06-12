// eslint-disable-next-line no-unused-vars
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
  "Wall",
];

const Header = () => {
  const [value, setValue] = useState();

  const theme = useTheme();
  console.log(theme);
  const isMatch = useMediaQuery(theme.breakpoints.down("md"));
  console.log(isMatch);
  return (
    <AppBar
      position="relative"
      sx={{
        backgroundColor: "black",
      }}
    >
      <Toolbar>
        <IconButton component={Link} to="/" color="inherit">
          <CarRental />
        </IconButton>
        {isMatch ? (
          <>
            <Typography variant="h5" sx={{ flexGrow: 1 }}>
              Auto Focus
            </Typography>
            <DrawerComp />
          </>
        ) : (
          <>
            <Tabs
              textColor="inherit"
              value={value}
              onChange={(e, value) => setValue(value)}
              sx={{ flexGrow: 1 }}
            >
              {PAGES.map((page, index) => (
                <Tab
                  key={index}
                  label={page}
                  component={Link}
                  to={`/${page.toLowerCase().replace(/ /g, "-")}`}
                  sx={{ textTransform: "capitalize" }} // Add styling here
                />
              ))}
            </Tabs>
            <div className="ml-auto flex gap-5">
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
