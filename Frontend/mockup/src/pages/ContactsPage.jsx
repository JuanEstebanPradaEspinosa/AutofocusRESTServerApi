// eslint-disable-next-line no-unused-vars
import React from "react";
import { Container, Typography, Box } from "@mui/material";

const ContactsPage = () => {
  return (
    <Container style={{ padding: "20px 0" }} maxWidth="md">
      <Typography variant="h4" gutterBottom>
        Contacts:
      </Typography>
      {/* Wanneer er geen contacten zijn gaan we dit ook zeggen op de pagina! */}
      <Box
        display="flex"
        justifyContent="center"
        alignItems="center"
        minHeight="60vh"
        flexDirection="column"
        textAlign="center"
      >
        <Typography variant="h6" color="textSecondary">
          Your contacts is empty.
        </Typography>
        <Typography variant="body1" color="textSecondary">
          Add contacts to your contactlist by sending a message to an car owner.
        </Typography>
      </Box>
    </Container>
  );
};

export default ContactsPage;
