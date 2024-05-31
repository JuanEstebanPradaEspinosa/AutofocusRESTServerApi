// eslint-disable-next-line no-unused-vars
import React from "react";
import { useState } from "react";
import {
  Typography,
  CssBaseline,
  Grid,
  Container,
  IconButton,
} from "@mui/material";

import { Add } from "@mui/icons-material";

import Header from "./layout/Header";
import Footer from "./components/Footer";
import CardsContainer from "./components/CardsContainer";
//import DetailsDialog from "./components/DetailsDialog";
// import MessageDialog from "./components/MessageDialog";
import RentCarPage from "./components/RentCarPage";
import CarCatalog from "./components/CarCatalog";
//import ContactListPage from "./components/chat/ContactListPage";

const App = () => {
  const [openRentCarDialog, setOpenRentCarDialog] = useState(false);
  const [cars, setCars] = useState([]); // Houd een lijst bij van toegevoegde auto's

  const handleOpenRentCarDialog = () => {
    setOpenRentCarDialog(true);
  };

  const handleCloseRentCarDialog = () => {
    setOpenRentCarDialog(false);
  };

  const handleAddCar = (carInfo) => {
    const updatedCars = [...cars, carInfo];
    setCars(updatedCars);
    console.log("Adding car:", carInfo);
    console.log("Cars:", updatedCars);
  };

  const handleSelectCar = (selectedCar) => {
    console.log("Selected car:", selectedCar);
  };

  return (
    <>
      <CssBaseline />
      {/* de header van de pagina */}
      <Header />

      {/* Hier zorgen we ervoor dat een gebruiker een auto kan toevoegen zegmaar aan zijn catalogus */}
      <div>
        <Grid container spacing={2} alignItems="center">
          <Grid item>
            <IconButton onClick={handleOpenRentCarDialog} color="primary">
              <Add />
            </IconButton>
          </Grid>
          <Grid item xs={6}></Grid> {/* Placeholder for spacing */}
          <Grid item xs={5} container justifyContent="flex-end"></Grid>
        </Grid>
        <RentCarPage
          open={openRentCarDialog}
          onClose={handleCloseRentCarDialog}
          onSubmit={handleAddCar}
        />
        {cars.length > 0 && (
          <div style={{ marginTop: "20px" }}>
            <CarCatalog cars={cars} onSelectCar={handleSelectCar} />
          </div>
        )}
      </div>
      {/* main gedeelte van de applicatie */}
      <main>
        <div style={{ padding: "20px" }}>
          <Container maxWidth="sm">
            <Typography
              variant="h2"
              align="center"
              color="textPrimary"
              gutterBottom
            >
              Car Rental
            </Typography>
            <Typography variant="h6" align="center" color="textSecondary">
              This is a longer paragraph wich is actually a Typography that is a
              fancy word for any text related element from html, I think the
              sentance is long enough. bla bla bla
            </Typography>
          </Container>
        </div>
        {/* container voor onze 'Cards" */}
        <CardsContainer />
      </main>
      <Footer />
    </>
  );
};

export default App;
