import React, { useState } from "react";
import {
  Grid,
  Card,
  CardMedia,
  CardContent,
  Typography,
  IconButton,
} from "@mui/material";
import { ArrowBack, ArrowForward } from "@mui/icons-material";

const CarCatalog = ({ cars }) => {
  return (
    <Grid container spacing={4}>
      {cars.map((car, index) => (
        <Grid item key={index} xs={12} sm={6} md={4}>
          <CarCard car={car} />
        </Grid>
      ))}
    </Grid>
  );
};

const CarCard = ({ car }) => {
  const [currentImageIndex, setCurrentImageIndex] = useState(0);

  const handleNextImage = () => {
    setCurrentImageIndex((prevIndex) => (prevIndex + 1) % car.imageUrls.length);
  };

  const handlePrevImage = () => {
    setCurrentImageIndex((prevIndex) =>
      prevIndex === 0 ? car.imageUrls.length - 1 : prevIndex - 1
    );
  };

  return (
    <Card style={{ height: "100%", display: "flex", flexDirection: "column" }}>
      {car.imageUrls && car.imageUrls.length > 0 && (
        <div style={{ position: "relative" }}>
          <CardMedia
            style={{ paddingTop: "56.25%" }}
            image={car.imageUrls[currentImageIndex]}
            title={`${car.brand} ${car.model}`}
          />
          {car.imageUrls.length > 1 && (
            <>
              <IconButton
                onClick={handlePrevImage}
                style={{
                  position: "absolute",
                  top: "50%",
                  left: "10px",
                  transform: "translateY(-50%)",
                  backgroundColor: "rgba(255, 255, 255, 0.7)",
                }}
              >
                <ArrowBack />
              </IconButton>
              <IconButton
                onClick={handleNextImage}
                style={{
                  position: "absolute",
                  top: "50%",
                  right: "10px",
                  transform: "translateY(-50%)",
                  backgroundColor: "rgba(255, 255, 255, 0.7)",
                }}
              >
                <ArrowForward />
              </IconButton>
            </>
          )}
        </div>
      )}
      <CardContent style={{ flexGrow: 1 }}>
        <Typography gutterBottom variant="h5">
          {car.brand} {car.model}
        </Typography>
        <Typography>Year: {car.year}</Typography>
        <Typography>Color: {car.color}</Typography>
      </CardContent>
    </Card>
  );
};

export default CarCatalog;
