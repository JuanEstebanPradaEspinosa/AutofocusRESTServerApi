// eslint-disable-next-line no-unused-vars
import React from "react";
import {
  Typography,
  Card,
  CardActions,
  CardContent,
  CardMedia,
  CssBaseline,
  Grid,
  Container,
  Button,
} from "@mui/material";

const cards = [1, 2, 3, 4, 5, 6, 7, 8, 9];

const catalogus = (match) => {
  const userId = match.params.id;
  // Fetch user cars based on userId (mock data here)
  const userCars = cards; // Replace with actual data fetching logic

  return (
    <Container style={{ padding: "20px 0" }} maxWidth="md">
      <Grid container spacing={4}>
        {userCars.map((card) => (
          <Grid item key={card} xs={12} sm={6} md={4}>
            <Card style={{ height: "100%", display: "flex", flexDirection: "column" }}>
              <CardMedia
                style={{ paddingTop: "56.25%" }}
                image="https://source.unsplash.com/random"
                title="Image title"
              />
              <CardContent style={{ flexGrow: 1 }}>
                <Typography gutterBottom variant="h5">
                  Car {card}
                </Typography>
                <Typography>
                  This car belongs to user {userId}. Description goes here.
                </Typography>
              </CardContent>
              <CardActions>
                <Button size="small" color="primary">
                  View details
                </Button>
                <Button size="small" color="primary">
                  Send message
                </Button>
              </CardActions>
            </Card>
          </Grid>
        ))}
      </Grid>
    </Container>
  );
};

export default catalogus;
