// eslint-disable-next-line no-unused-vars
import React from "react";
import { useState } from "react";
import { Container, Typography, Box, Grid, IconButton } from "@mui/material";
import { Add } from "@mui/icons-material";
import RentCarPage from "../components/RentCarPage";
import CarCatalog from "../components/CarCatalog";

const MyCollectionPage = () => {
  const [openRentCarDialog, setOpenRentCarDialog] = useState(false);
  const [cars, setCars] = useState([]); // Maintain a list of added cars

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

  return (
    <>
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
      </div>
      <Container style={{ padding: "20px 0" }} maxWidth="md">
        <Typography variant="h4" gutterBottom>
          My collection:
        </Typography>
        {cars.length === 0 ? (
          <Box
            display="flex"
            justifyContent="center"
            alignItems="center"
            minHeight="60vh"
            flexDirection="column"
            textAlign="center"
          >
            <Typography variant="h6" color="textSecondary">
              Your collection is empty.
            </Typography>
            <Typography variant="body1" color="textSecondary">
              Add cars to your collection by clicking on the Add button.
            </Typography>
          </Box>
        ) : (
          <CarCatalog cars={cars} />
        )}
      </Container>
    </>
  );
};

export default MyCollectionPage;
